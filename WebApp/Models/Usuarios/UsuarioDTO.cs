using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Usuarios
{
    public class UsuarioDTO
    {
        public required string Usuario { get; set; }
        public required string Contrasenia { get; set; }
        public required string ConfirmarContrasenia { get; set; }
        public int IdGrupo { get; set; }
    }
}