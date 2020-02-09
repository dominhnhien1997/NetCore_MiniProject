using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Activitie
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activities, ActivitiesDto>();
            CreateMap<UserActivity, AttendeeDto>()
                .ForMember(u => u.Username, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(u => u.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName));
        }
    }
}
