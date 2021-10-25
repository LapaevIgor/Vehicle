using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.BLL.Models;

namespace Vehicle.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task<User> AddAsync(User user);

        Task<User> UpdateAsync(User user);

        Task DeleteByIdAsync(int id);

        Task DeleteAsync(User user);
    }
}
