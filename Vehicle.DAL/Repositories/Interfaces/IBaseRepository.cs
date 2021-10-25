using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vehicle.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteByIdAsync(int id);

        Task DeleteAsync(T entity);

        Task SaveAsync();
    }
}
