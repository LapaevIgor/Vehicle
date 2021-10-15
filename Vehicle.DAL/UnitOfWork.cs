using System;
using Microsoft.Extensions.DependencyInjection;
using Vehicle.DAL.Interfaces;
using Vehicle.DAL.Repositories.Interfaces;

namespace Vehicle.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly AppDbContext _context;
        private IServiceProvider _serviceProvider;

        public UnitOfWork(AppDbContext appDbContextcontext, IServiceProvider serviceProvider)
        {
            _context = appDbContextcontext;
            _serviceProvider = serviceProvider;
        }

        public IUserRepository UserRepository => new Lazy<IUserRepository>(() => GetInstance<IUserRepository>()).Value;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        private T GetInstance<T>() 
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
