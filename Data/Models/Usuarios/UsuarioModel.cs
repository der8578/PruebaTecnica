using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models.Grupo;

namespace Data.Models.Usuarios
{
    [Table(name: "Usuario")]
    public class UsuarioModel
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string ContraseniaHash { get; set; }

        [ForeignKey("Grupo")]
        public int IdGrupo { get; set; }

        public GrupoModel Grupo { get; set; }
    }
}
