using Microsoft.Extensions.DependencyInjection;
using Vehicle.BLL.MappingProfiles;
using Vehicle.Web.MappingProfiles;

namespace Vehicle.Web.Extensions
{
    public static class AutomapperRuleAgent
    {
        public static void UseAutomapperRules(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DataToDomainProfile), typeof(DomainToModelProfile));
            services.AddAutoMapper(typeof(DomainToDataProfile), typeof(ModelToDomainProfile));
        }
    }
}
