using System.Collections.Generic;

namespace Vehicle.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T Create(T entity);

        T Update(T entity);

        void DeleteById(int id);

        void Delete(T entity);

        void Save();
    }
}
