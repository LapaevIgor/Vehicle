using AutoMapper;
using Vehicle.BLL.Models;
using Vehicle.ViewModels.Users;

namespace Vehicle.Web.MappingProfiles
{
    public class ModelToDomainProfile : Profile
    {
        public ModelToDomainProfile()
        {
            CreateMap<UserModel, User>();
        }
    }
}
