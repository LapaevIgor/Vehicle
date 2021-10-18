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
                .ForMember(d => d.UserPhoneNumbers, o => o.MapFrom(s => s.UserPhoneNumbers));

            CreateMap<UserPhoneNumber, UserPhoneNumberDb>();
        }
    }
}