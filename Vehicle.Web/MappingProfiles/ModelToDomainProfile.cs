using AutoMapper;
using Vehicle.BLL.Models;
using Vehicle.ViewModels.CarBrands;
using Vehicle.ViewModels.Users;

namespace Vehicle.Web.MappingProfiles
{
    public class ModelToDomainProfile : Profile
    {
        public ModelToDomainProfile()
        {
            CreateMap<UserModel, User>()
                .ForMember(d => d.UserPhoneNumbers, o => o.MapFrom(s => s.PhoneNumbers));

            CreateMap<UserPhoneNumberModel, UserPhoneNumber>();

            CreateMap<CarBrandModel, CarBrand>();
        }
    }
}