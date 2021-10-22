using Vehicle.DAL.Entities;

namespace Vehicle.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserDb>
    {
        bool Exists(int id);
    }
}