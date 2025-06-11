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

        public async Task<UsuarioModel> Login(string Usuario, string Contrasenia)
        {
            try
            {
                var User = await repository.GetUsuarioByName(Usuario);
                if (User != null)
                {
                    bool ContraseniaValida = VerifyPassword(Contrasenia, User.ContraseniaHash);
                    if (ContraseniaValida)
                    {
                        return User;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
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

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }
    }
}