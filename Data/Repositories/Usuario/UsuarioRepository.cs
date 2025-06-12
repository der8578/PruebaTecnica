using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces.Usuario;
using Data.Models.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(UsuarioModel model)
        {
            try
            {
                await dbContext.Set<UsuarioModel>().AddAsync(model);
                await dbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UsuarioModel>> GetAllAsync(string? searchTerm = null)
        {
            try
            {
                var query = dbContext.Set<UsuarioModel>().AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query = query.Where(x => x.Nombre.Contains(searchTerm));
                }
                return await query.Include(x => x.Grupo).ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<UsuarioModel> GetUsuarioByName(string Nombre)
        {
            try
            {
                return await dbContext.Usuarios
                    .Where(x => x.Nombre == Nombre).Include(x => x.Grupo).FirstOrDefaultAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}