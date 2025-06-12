using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces.Formula;
using Data.Models.Formula;
using Data.Models.FormulaMateriales;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Formula
{
    public class FormulaRepository : IFormulaRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FormulaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(FormulaModel model)
        {
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                dbContext.Formulas.Add(model);
                await dbContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (System.Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<FormulaModel>> GetAllAsync(string? searchTerm = null)
        {
            try
            {
                var query = dbContext.Formulas.AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query = query.Where(x => x.Nombre.Contains(searchTerm));
                }
                return await query.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<FormulaModel> GetByIdAsync(int id)
        {
            return await dbContext.Formulas.Include(x => x.Materiales).FirstOrDefaultAsync(x => x.IdFormula == id);
        }

        public async Task UpdateAsync(FormulaModel model)
        {
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                var formula = await dbContext.Formulas
                    .Include(f => f.Materiales)
                    .FirstOrDefaultAsync(f => f.IdFormula == model.IdFormula);

                dbContext.RemoveRange(formula.Materiales);

                formula.Nombre = model.Nombre;
                formula.Cantidad = model.Cantidad;

                formula.Materiales = model.Materiales
                    .Select(m => new FormulaMaterialesModel
                    {
                        IdFormula = formula.IdFormula,
                        IdProducto = m.IdProducto,
                        Nombre = m.Nombre,
                        Cantidad = m.Cantidad
                    }).ToList();
                await dbContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (System.Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}