using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.Formula;
using Data.Models.Producto;

namespace Data.Models.FormulaMateriales
{
    [Table(name: "FormulaMateriales")]
    public class FormulaMaterialesModel
    {
        [Key, Column(Order = 0)]
        public int IdFormula { get; set; }

        [Key, Column(Order = 1)]
        public int IdProducto { get; set; }

        [Required]
        public string Nombre { get; set; }

        public decimal Cantidad { get; set; }

        [ForeignKey("IdFormula")]
        public FormulaModel? Formula { get; set; }

        [ForeignKey("IdProducto")]
        public ProductoModel? Producto { get; set; }
    }
}