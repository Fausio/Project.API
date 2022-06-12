using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Interface
{
    public interface IGeneric<T> where T : class
    {
        Task Create(T obj);
        Task Update(T obj);
        Task Delete(T obj);
        Task Get(int Id);
        Task<List<T>> Get();
    }
}
