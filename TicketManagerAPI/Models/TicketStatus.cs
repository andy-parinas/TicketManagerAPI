using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Models
{
    public class TicketStatus
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }


    }
}
