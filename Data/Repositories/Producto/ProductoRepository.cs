using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Data.Interfaces.Producto;
using Data.Models.Producto;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Producto
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(ProductoModel model)
        {
            try
            {
                dbContext.Productos.Add(model);
                await dbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductoModel>> GetAllAsync(string? searchTerm = null)
        {
            try
            {
                var query = dbContext.Productos.AsQueryable();
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

        public async Task<ProductoModel> GetByIdAsync(int id)
        {
            try
            {
                return await dbContext.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(ProductoModel model)
        {
            try
            {
                dbContext.Productos.Update(model);
                await dbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}