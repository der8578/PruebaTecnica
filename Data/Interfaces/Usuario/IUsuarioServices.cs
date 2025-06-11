using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.Usuarios;

namespace Data.Interfaces.Usuario
{
    public interface IUsuarioServices
    {
        Task<IEnumerable<UsuarioModel>> ObtenerUsuarios(string? searchTerm = null);
        Task Grabar(UsuarioModel model);
    }
}