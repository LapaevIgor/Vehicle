using System.Linq;
using System.Threading.Tasks;
using Vehicle.DAL.Entities;
using Vehicle.DAL.Repositories.Interfaces;

namespace Vehicle.DAL.Repositories.Implementations
{
    public class UserRepository : BaseRepository<UserDb>, IUserRepository
    {
        readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<UserDb> UpdateAsync(UserDb user)
        {
            var existingPhoneNumbersFromDb = _context.UserPhoneNumbers.Where(u => u.UserId == user.Id);
            _context.UserPhoneNumbers.RemoveRange(existingPhoneNumbersFromDb);

            var result = _context.Update(user).Entity;
            await _context.SaveChangesAsync();
            return result;
        }

        public bool Exists(int id)
        {
            var exisitngUser = base.GetByIdAsync(id);
            if (exisitngUser is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}