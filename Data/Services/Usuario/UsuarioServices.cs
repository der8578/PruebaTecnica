using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces.Usuario;
using Data.Models.Usuarios;

namespace Data.Services.Usuario
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository repository;

        public UsuarioServices(IUsuarioRepository repository)
        {
            this.repository = repository;
        }
        public async Task Grabar(UsuarioModel model)
        {
            try
            {
                string Contrasenia = BCrypt.Net.BCrypt.HashPassword(model.ContraseniaHash);
                model.ContraseniaHash = Contrasenia;
                await repository.AddAsync(model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<UsuarioModel>> ObtenerUsuarios(string? searchTerm = null)
        {
            try
            {
                return await repository.GetAllAsync(searchTerm);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}