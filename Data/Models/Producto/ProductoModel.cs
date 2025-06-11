using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models.Producto
{
    [Table(name: "Producto")]
    public class ProductoModel
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Unidad { get; set; }
    }
}