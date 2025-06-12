using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces.Formula;
using Data.Models.Formula;

namespace Data.Services.Formula
{
    public class FormulaServices : IFormulaServices
    {
        private readonly IFormulaRepository repository;

        public FormulaServices(IFormulaRepository repository)
        {
            this.repository = repository;
        }
        public async Task Actualizar(FormulaModel model)
        {
            try
            {
                await repository.UpdateAsync(model);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task Grabar(FormulaModel model)
        {
            try
            {
                await repository.AddAsync(model);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<FormulaModel> ObtenerFormulaPorId(int Id)
        {
            try
            {
                return await repository.GetByIdAsync(Id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<FormulaModel>> ObtenerFormulas(string? searchTerm = null)
        {
            try
            {
                return repository.GetAllAsync(searchTerm);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}