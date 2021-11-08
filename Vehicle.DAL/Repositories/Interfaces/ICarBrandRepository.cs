using System.Threading.Tasks;
using Vehicle.DAL.Entities;

namespace Vehicle.DAL.Repositories.Interfaces
{
    public interface ICarBrandRepository : IBaseRepository<CarBrandDb>
    {
        Task<CarBrandDb> GetByNameAsync(string name);

        Task DeleteByNameAsync(string name);
    }
}