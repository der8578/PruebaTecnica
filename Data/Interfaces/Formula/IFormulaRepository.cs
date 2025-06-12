using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces.Crud;
using Data.Models.Formula;

namespace Data.Interfaces.Formula
{
    public interface IFormulaRepository : IGetAll<FormulaModel>, IAdd<FormulaModel>, IUpdate<FormulaModel>, IGetById<FormulaModel>
    {

    }
}