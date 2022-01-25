using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServices
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(string query);
        Task<List<T>> GetByIdAsync(int id, string query);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
