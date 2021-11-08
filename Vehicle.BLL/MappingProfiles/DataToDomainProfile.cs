using AutoMapper;
using Vehicle.BLL.Models;
using Vehicle.DAL.Entities;

namespace Vehicle.BLL.MappingProfiles
{
    public class DataToDomainProfile : Profile
    {
        public DataToDomainProfile()
        {
            CreateMap<UserDb, User>()
                .ForMember(d => d.UserPhoneNumbers, o => o.MapFrom(s => s.UserPhoneNumbers))
                .ForMember(d => d.FavoriteCarBrand, o => o.MapFrom(s => s.FavoriteCarBrand));

            CreateMap<UserPhoneNumberDb, UserPhoneNumber>();

            CreateMap<CarBrandDb, CarBrand>();
        }
    }
}