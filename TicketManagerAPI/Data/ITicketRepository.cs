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

        Task<Ticket> GetTicket(int id);

        Task<bool> Save();

        void Create(Ticket ticket);

        void Delete(Ticket ticket);
    }
}
