using AutoMapper;
using Vehicle.BLL.Models;
using Vehicle.ViewModels.Users;

namespace Vehicle.Web.MappingProfiles
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
