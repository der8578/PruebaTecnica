using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.Producto;

namespace Data.Interfaces.Producto
{
    public interface IProductoServices
    {
        Task<IEnumerable<ProductoModel>> ObtenerProductos(string? searchTerm = null);
    }
}