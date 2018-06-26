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


        public async Task<Ticket> GetTicket(int id)
        {
            var ticket = await _context.Tickets
                            .Include(t => t.AssignedTo)
                            .Include(t => t.CreatedBy)
                            .Include(t => t.TicketStatus)
                            .Include(t => t.TicketPriority)
                            .Include(t => t.TicketType)
                            .Include(t => t.TicketQueue)
                            .Include(t => t.Client).ThenInclude(c => c.ClientType)
                            .Include(t => t.ConfigItem).ThenInclude(c => c.ConfigItemType)
                            .FirstOrDefaultAsync(t => t.Id == id);

            return ticket;
        }

        public async Task<PageList<Ticket>> GetTickets(TicketParams ticketParams)
        {
            var tickets = _context.Tickets
                            .Include(t => t.CreatedBy)
                            .Include(t => t.AssignedTo)
                            .Include(t => t.TicketPriority)
                            .Include(t => t.TicketStatus)
                            .Include(t => t.TicketType)
                            .Include(t => t.TicketQueue)
                            .AsQueryable();

            if (ticketParams.AssignedTo > 0)
                tickets = tickets.Where(t => t.AssignedToId == ticketParams.AssignedTo);

            if (ticketParams.CreatedBy > 0)
                tickets = tickets.Where(t => t.CreatedById == ticketParams.CreatedBy);

            if (!string.IsNullOrEmpty(ticketParams.Filter))
                tickets = tickets.Where(t => t.Description.Contains(ticketParams.Filter) || t.Details.Contains(ticketParams.Filter));


            tickets = Sort(tickets, ticketParams.Sort, ticketParams.Direction);

            return await PageList<Ticket>.CreateAsync(tickets, ticketParams.PageNumber, ticketParams.PageSize);
        }

        private IQueryable<Ticket> Sort(IQueryable<Ticket> tickets, string sort, string direction)
        {

            var sortedTickets = tickets;

            if (direction == "ASC")
            {
                switch (sort.ToLower())
                {
                    case "number":
                        sortedTickets = tickets.OrderBy(x => x.Number);
                        break;
                    case "status":
                        sortedTickets = tickets.OrderBy(x => x.TicketStatus.Name);
                        break;
                    case "priority":
                        sortedTickets = tickets.OrderBy(x => x.TicketPriority.Name);
                        break;
                    case "type":
                        sortedTickets = tickets.OrderBy(x => x.TicketType.Name);
                        break;
                    case "updatedat":
                        sortedTickets = tickets.OrderBy(x => x.UpdatedAt);
                        break;
                    default:
                        sortedTickets = tickets.OrderBy(x => x.CreatedAt);
                        break;
                }

            }
            else
            {

                switch (sort.ToLower())
                {
                    case "number":
                        sortedTickets = tickets.OrderByDescending(x => x.Number);
                        break;
                    case "status":
                        sortedTickets = tickets.OrderByDescending(x => x.TicketStatus.Name);
                        break;
                    case "priority":
                        sortedTickets = tickets.OrderByDescending(x => x.TicketPriority.Name);
                        break;
                    case "type":
                        sortedTickets = tickets.OrderByDescending(x => x.TicketType.Name);
                        break;
                    case "updatedat":
                        sortedTickets = tickets.OrderByDescending(x => x.UpdatedAt);
                        break;
                    default:
                        sortedTickets = tickets.OrderByDescending(x => x.CreatedAt);
                        break;
                }

            }

            return sortedTickets;
        }


        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Create(Ticket ticket)
        {
            var prefix = "";

            switch (ticket.TicketType.Name)
            {
                case "Incident":
                    prefix = "INC";
                    break;
                case "Service Request":
                    prefix = "SR";
                    break;
                case "Change":
                    prefix = "CR";
                    break;
                case "Problem":
                    prefix = "PRO";
                    break;
                default:
                    prefix = "CR";
                    break;
            }
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            var ticketNumber = $"{prefix}-{unixTimestamp}";

            ticket.Number = ticketNumber;

            _context.Add(ticket);
        }

        public void Delete(Ticket ticket)
        {
            _context.Remove(ticket);
        }

        public async Task<TicketStatus> GetTicketStatus(int id)
        {
            var status = await _context.TicketStatus.FirstOrDefaultAsync(s => s.Id == id);

            return status;
        }

        public async Task<TicketPriority> GetTicketPriority(int id)
        {
            var priority = await _context.TicketPriorities.FirstOrDefaultAsync(p => p.Id == id);

            return priority;
        }

        public async Task<TicketType> GetTicketType(int id)
        {
            var type = await _context.TicketTypes.FirstOrDefaultAsync(t => t.Id == id);

            return type;
        }

        public async Task<TicketQueue> GetTicketQueue(int id)
        {
            var queue = await _context.TicketQueues.FirstOrDefaultAsync(q => q.Id == id);

            return queue;
        }

        public async Task<ICollection<TicketStatus>> GetTicketStatuses()
        {
            var statuses = await _context.TicketStatus.ToListAsync();

            return statuses;
        }

        public async Task<ICollection<TicketPriority>> GetTicketPriorities()
        {
            var priorities = await _context.TicketPriorities.ToListAsync();

            return priorities;
        }

        public async Task<ICollection<TicketType>> GetTicketTypes()
        {
            var types = await _context.TicketTypes.ToListAsync();

            return types;
        }

        public async Task<ICollection<TicketQueue>> GetTicketQueues()
        {
            var queues = await _context.TicketQueues.ToListAsync();

            return queues;
        }
    }
}
