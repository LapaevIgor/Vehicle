using AutoMapper;
using Vehicle.BLL.Models;
using Vehicle.ViewModels.CarBrands;
using Vehicle.ViewModels.Users;

namespace Vehicle.Web.MappingProfiles
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(d => d.PhoneNumbers, o => o.MapFrom(s => s.UserPhoneNumbers));

            CreateMap<UserPhoneNumber, UserPhoneNumberModel>();

            CreateMap<CarBrand, CarBrandModel>();
        }
    }
}