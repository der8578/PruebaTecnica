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
        public async Task<IEnumerable<ProductoModel>> ObtenerProductos(string? searchTerm = null)
        {
            return await repository.GetAllAsync(searchTerm);
        }
    }
}