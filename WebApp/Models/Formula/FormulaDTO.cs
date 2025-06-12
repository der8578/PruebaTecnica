using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.FormulaMateriales;

namespace WebApp.Models.Formula
{
    public class FormulaDTO
    {
        public int IdFormula { get; set; }
        public string? Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public List<FormulaMaterialesModel> Materiales { get; set; } = new();
    }
}