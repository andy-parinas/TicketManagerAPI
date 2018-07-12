using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagerAPI.Helpers;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Data
{
    public interface ITicketRepository
    {


        Task<PageList<Ticket>> GetTickets(TicketParams ticketParams);

        Task<int> GetTicketCount(TicketParams ticketParams);

        Task<Ticket> GetTicket(int id);

        Task<bool> Save();

        void Create(Ticket ticket);

        void Delete(Ticket ticket);

        Task<TicketStatus> GetTicketStatus(int id);

        Task<ICollection<TicketStatus>> GetTicketStatuses();

        Task<TicketPriority> GetTicketPriority(int id);

        Task<ICollection<TicketPriority>> GetTicketPriorities();

        Task<TicketType> GetTicketType(int id);

        Task<ICollection<TicketType>> GetTicketTypes();

        Task<TicketQueue> GetTicketQueue(int id);

        Task<ICollection<TicketQueue>> GetTicketQueues();

        Task<ICollection<Journal>> GetJournals(int ticketId);

        Task<Journal> GetJournal(int id);

        void AddJournal(Journal journal);

        void RemoveJournal(Journal journal);
        
    }
}
