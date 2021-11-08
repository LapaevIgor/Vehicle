using Microsoft.Extensions.DependencyInjection;
using Vehicle.BLL.Services;
using Vehicle.BLL.Services.Interfaces;
using Vehicle.DAL;
using Vehicle.DAL.Interfaces;
using Vehicle.DAL.Repositories.Implementations;
using Vehicle.DAL.Repositories.Interfaces;

namespace Vehicle.Web.Extensions
{
    public static class DependencyRegistrationAgent
    {
        public static void RegisterServiceDependencies(this IServiceCollection services)
        {
            RegisterBllDependencies(services);
            RegisterDalDependencies(services);
        }

        private static void RegisterBllDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarBrandService, CarBrandService>();
        }

        private static void RegisterDalDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarBrandRepository, CarBrandRepository>();
        }
    }
}
