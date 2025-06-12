using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.Formula;

namespace Data.Interfaces.Formula
{
    public interface IFormulaServices
    {
        Task<IEnumerable<FormulaModel>> ObtenerFormulas(string? searchTerm = null);
        Task<FormulaModel> ObtenerFormulaPorId(int Id);
        Task Grabar(FormulaModel model);
        Task Actualizar(FormulaModel model);
    }
}