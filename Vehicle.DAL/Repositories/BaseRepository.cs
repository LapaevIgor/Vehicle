using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public virtual async Task<T> CreateAsync(T entity)
        {
            var result = context.Add(entity).Entity;
            await context.SaveChangesAsync();
            return result;
        }

        public async Task DeleteAsync(T entity)
        {
            context.Remove<T>(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            await DeleteAsync(context.Find<T>(id));
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await context.FindAsync<T>(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var result = context.Update(entity).Entity;
            await context.SaveChangesAsync();
            return result; 
        }
    }
}
