using Vehicle.DAL.Repositories.Interfaces;

namespace Vehicle.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ICarBrandRepository CarBrandRepository { get; }

        void SaveChanges();
    }
}
