using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces.Crud;
using Data.Models.Usuarios;

namespace Data.Interfaces.Usuario
{
    public interface IUsuarioRepository : IGetAll<UsuarioModel>, IAdd<UsuarioModel>
    {
        Task<UsuarioModel> GetUsuarioByName(string Nombre);
    }
}