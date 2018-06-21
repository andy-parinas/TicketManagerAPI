using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int CreatedById { get; set; }

        [Required]
        public User CreatedBy { get; set; }

        public int AssignedToId { get; set; }

        public User AssignedTo { get; set; }

        public int TicketTypeId { get; set; }

        public TicketType TicketType { get; set; }

        public int TicketPriorityId { get; set; }

        public TicketPriority TicketPriority { get; set; }

        public int TicketStatusId { get; set; }

        public TicketStatus TicketStatus { get; set; }

    }
}
