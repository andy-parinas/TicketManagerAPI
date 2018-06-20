using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagerAPI.Helpers;
using TicketManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketManagerAPI.Data
{
    public class TicketRepository : ITicketRepository
    {

        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetTicket()
        {
            throw new NotImplementedException();
        }

        public async Task<PageList<Ticket>> GetTickets(TicketParams ticketParams)
        {
            var tickets = _context.Tickets
                            .Include(t => t.CreatedBy).Include(t => t.AssignedTo)
                            .AsQueryable();

            if (ticketParams.AssignedTo > 0)
                tickets = tickets.Where(t => t.AssignedToId == ticketParams.AssignedTo);

            if (ticketParams.CreatedBy > 0)
                tickets = tickets.Where(t => t.CreatedById == ticketParams.CreatedBy);

            if (!string.IsNullOrEmpty(ticketParams.Filter))
                tickets = tickets.Where(t => t.Description.Contains(ticketParams.Filter) || t.Details.Contains(ticketParams.Filter));

            return await PageList<Ticket>.CreateAsync(tickets, ticketParams.PageNumber, ticketParams.PageSize);
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}
