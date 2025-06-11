using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces.Crud
{
    public interface IDelete
    {
        Task DeleteAsync(int id);
    }
}