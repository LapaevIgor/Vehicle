using System.Collections.Generic;
using Vehicle.DAL.Repositories.Interfaces;

namespace Vehicle.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        readonly AppDbContext context;

        public BaseRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public virtual T Create(T entity)
        {
            var result = context.Add(entity).Entity;
            context.SaveChanges();
            return result;
        }

        public void Delete(T entity)
        {
            context.Remove<T>(entity);
            context.SaveChanges();
        }

        public virtual void DeleteById(int id)
        {
            Delete(context.Find<T>(id));
        }

        public virtual T GetById(int id)
        {
            return context.Find<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            var result = context.Update(entity).Entity;
            context.SaveChanges();
            return result; 
        }
    }
}
