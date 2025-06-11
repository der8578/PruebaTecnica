using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces.Crud
{
    public interface IUpdate<T> where T : class
    {
        Task UpdateAsync(T model);
    }
}