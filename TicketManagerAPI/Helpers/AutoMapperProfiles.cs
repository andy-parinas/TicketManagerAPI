using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagerAPI.Dto;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDetailDto>()
                .ForMember(d => d.NumberOfCreatedTickets, o => o.MapFrom(u => u.CreatedTickets.Count()))
                .ForMember(d => d.NumberAssignedTickets, o => o.MapFrom(u => u.AssignedTickets.Count()));

            CreateMap<User, UserInfoDto>();

            CreateMap<Ticket, TicketListDto>();

            CreateMap<Ticket, TicketInfoDto>();

        }

    }
}
