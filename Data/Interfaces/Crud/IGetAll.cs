using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces.Crud
{
    public interface IGetAll<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string? searchTerm = null);
    }
}