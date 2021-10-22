using System.Linq;
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

        public override UserDb Update(UserDb user)
        {
            var existingPhoneNumbersFromDb = _context.UserPhoneNumbers.Where(u => u.UserId == user.Id);
            _context.UserPhoneNumbers.RemoveRange(existingPhoneNumbersFromDb);

            var result = _context.Update(user).Entity;
            _context.SaveChanges();
            return result;
        }

        public bool Exists(int id)
        {
            var exisitngUser = base.GetById(id);
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