using Vehicle.DAL.Repositories.Interfaces;

namespace Vehicle.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        void SaveChanges();
    }
}
