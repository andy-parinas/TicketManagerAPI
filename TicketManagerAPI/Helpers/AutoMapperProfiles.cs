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

            CreateMap<Ticket, TicketListDto>()
                .ForMember(d => d.Priority, o => o.MapFrom(t => t.TicketPriority.Name))
                .ForMember(d => d.Status, o => o.MapFrom(t => t.TicketStatus.Name))
                .ForMember(d => d.TicketType, o => o.MapFrom(t => t.TicketType.Name))
                .ForMember(d => d.Queue, o => o.MapFrom(t => t.TicketQueue.Name));

            CreateMap<Ticket, TicketDetailDto>()
              .ForMember(d => d.Priority, o => o.MapFrom(t => t.TicketPriority.Name))
              .ForMember(d => d.Status, o => o.MapFrom(t => t.TicketStatus.Name))
              .ForMember(d => d.TicketType, o => o.MapFrom(t => t.TicketType.Name))
              .ForMember(d => d.Queue, o => o.MapFrom(t => t.TicketQueue.Name)); 

            CreateMap<Ticket, TicketInfoDto>();

            CreateMap<ConfigItem, ConfigItemInfoDto>()
                .ForMember(d => d.ConfigItemType, o => o.MapFrom(c => c.ConfigItemType.Name));

            CreateMap<Client, ClientInfoDto>()
                .ForMember(d => d.ClientType, o => o.MapFrom(c => c.ClientType.Name));

        }

    }
}
