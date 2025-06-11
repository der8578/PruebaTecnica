using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Usuarios
{
    public class LoginDTO
    {
        public required string Usuario { get; set; }
        public required string Contrasenia { get; set; }
    }
}