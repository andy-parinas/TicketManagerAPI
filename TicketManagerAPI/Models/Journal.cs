using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Models
{
    public class Journal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Entry { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

        public int CreatedById { get; set; }

        public User CreatedBy { get; set; }

    }
}
