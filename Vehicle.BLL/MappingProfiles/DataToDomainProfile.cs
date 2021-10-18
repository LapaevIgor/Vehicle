﻿using AutoMapper;
using Vehicle.BLL.Models;
using Vehicle.DAL.Entities;

namespace Vehicle.BLL.MappingProfiles
{
    public class DataToDomainProfile : Profile
    {
        public DataToDomainProfile()
        {
            CreateMap<UserDb, User>()
                .ForMember(d => d.UserPhoneNumbers, o => o.MapFrom(s => s.UserPhoneNumbers));

            CreateMap<UserPhoneNumberDb, UserPhoneNumber>();
        }
    }
}