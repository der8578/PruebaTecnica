using Data.Interfaces.Grupo;
using Data.Models.Grupo;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Grupo
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly ApplicationDbContext dbContext;

        public GrupoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<GrupoModel>> GetAllAsync(string? searchTerm = null)
        {
            try
            {
                var query = dbContext.Set<GrupoModel>().AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query = query.Where(x => x.Nombre.Contains(searchTerm));
                }
                return await query.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}