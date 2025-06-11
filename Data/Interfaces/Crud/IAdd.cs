using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces.Crud
{
    public interface IAdd<T> where T : class
    {
        Task AddAsync(T model);
    }
}