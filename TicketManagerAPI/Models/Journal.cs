using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Models
{
    public class Journal
    {
        public int Id { get; set; }

        public string Entry { get; set; }

        public DateTime CreatedAt { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

        public int CreatedById { get; set; }

        public User CreatedBy { get; set; }

    }
}
