using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vehicle.DAL.Entities;
using Vehicle.DAL.Repositories.Interfaces;

namespace Vehicle.DAL.Repositories.Implementations
{
    public class CarBrandRepository : BaseRepository<CarBrandDb>, ICarBrandRepository
    {
        readonly AppDbContext _context;

        public CarBrandRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<CarBrandDb> GetByNameAsync(string name)
        {
            return await _context.CarBrands.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task DeleteByNameAsync(string name)
        {
            _context.Remove(await GetByNameAsync(name));
            await _context.SaveChangesAsync();
        }
    }
}