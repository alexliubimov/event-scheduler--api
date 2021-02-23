using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;
using Test.EventScheduler.DataAccess.Models;

namespace Test.EventScheduler.MapperConfigurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.AttendeesNumber, opt => opt.MapFrom(s => s.Attendees.Count))
                .ForMember(dest => dest.OrganizerName, opt => opt.MapFrom(s => $"{s.EventOrganizer.FirstName} {s.EventOrganizer.LastName}"));

            CreateMap<User, UserDto>();

            CreateMap<CreateUserDto, User>();
        }
    }
}
