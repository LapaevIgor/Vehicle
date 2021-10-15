using Vehicle.DAL.Entities;
using Vehicle.DAL.Repositories.Interfaces;

namespace Vehicle.DAL.Repositories.Implementations
{
    public class UserRepository : BaseRepository<UserDb>, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context)
        {

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