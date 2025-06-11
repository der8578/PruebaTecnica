using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces.Crud
{
    public interface IGetById<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
    }
}