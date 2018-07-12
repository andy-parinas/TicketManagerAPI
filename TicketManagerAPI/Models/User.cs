using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public ICollection<Ticket> CreatedTickets { get; set; }

        public ICollection<Ticket> AssignedTickets { get; set; }

        public ICollection<Journal> Journals { get; set; }

        public string GetFullName()
        {
            return $"{this.FirstName} {this.LastName}";
        }

    }
}
