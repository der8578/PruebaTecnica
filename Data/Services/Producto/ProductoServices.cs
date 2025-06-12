using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces.Producto;
using Data.Models.Producto;

namespace Data.Services.Producto
{
    public class ProductoServices : IProductoServices
    {
        private readonly IProductoRepository repository;

        public ProductoServices(IProductoRepository repository)
        {
            this.repository = repository;
        }

        public async Task Actualizar(ProductoModel model)
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

        public async Task Grabar(ProductoModel model)
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

        public async Task<ProductoModel> ObtenerProductoPorId(int Id)
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

        public async Task<IEnumerable<ProductoModel>> ObtenerProductos(string? searchTerm = null)
        {
            return await repository.GetAllAsync(searchTerm);
        }
    }
}