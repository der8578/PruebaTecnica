using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.Usuarios;

namespace Data.Models.Grupo
{
    [Table(name: "Grupo")]
    public class GrupoModel
    {
        [Key]
        public int IdGrupo { get; set; }

        [Required]
        public string Nombre { get; set; }

        // Navegación
        public ICollection<UsuarioModel> Usuarios { get; set; }
    }
}