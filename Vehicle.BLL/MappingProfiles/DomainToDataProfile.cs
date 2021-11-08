using AutoMapper;
using Vehicle.BLL.Models;
using Vehicle.DAL.Entities;

namespace Vehicle.BLL.MappingProfiles
{
    public class DomainToDataProfile : Profile
    {
        public DomainToDataProfile()
        {
            CreateMap<User, UserDb>()
                .ForMember(d => d.UserPhoneNumbers, o => o.MapFrom(s => s.UserPhoneNumbers))
                .ForMember(d => d.FavoriteCarBrandId, o => o.MapFrom(s => s.FavoriteCarBrand.Id))
                .ForMember(d => d.FavoriteCarBrand, o => o.Ignore());

            CreateMap<UserPhoneNumber, UserPhoneNumberDb>();

            CreateMap<CarBrand, CarBrandDb>();
        }
    }
}