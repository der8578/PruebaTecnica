using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.FormulaMateriales;
using Data.Models.Producto;

namespace Data.Models.Formula
{
    [Table(name: "Formula")]
    public class FormulaModel
    {
        [Key]
        public int IdFormula { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        public ProductoModel Producto { get; set; }

        [Required]
        public string Nombre { get; set; }

        public decimal Cantidad { get; set; }

        public ICollection<FormulaMaterialesModel> Materiales { get; set; }
    }
}