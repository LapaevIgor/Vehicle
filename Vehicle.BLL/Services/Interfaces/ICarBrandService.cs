using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.BLL.Models;

namespace Vehicle.BLL.Services.Interfaces
{
    public interface ICarBrandService
    {
        Task<IEnumerable<CarBrand>> GetAllAsync();

        Task<CarBrand> GetByIdAsync(int id);

        Task<CarBrand> GetByNameAsync(string name);

        Task<CarBrand> AddAsync(CarBrand carBrand);

        Task<CarBrand> UpdateAsync(CarBrand carBrand);

        Task DeleteByIdAsync(int id);

        Task DeleteByNameAsync(string name);
    }
}