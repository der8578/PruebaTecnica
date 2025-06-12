using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces.Crud;
using Data.Models.Producto;

namespace Data.Interfaces.Producto
{
    public interface IProductoRepository
    : IGetAll<ProductoModel>
        , IGetById<ProductoModel>
        , IAdd<ProductoModel>
        , IUpdate<ProductoModel>
    {

    }
}