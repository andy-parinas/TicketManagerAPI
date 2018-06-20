using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Dto
{
    public class UserRegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage ="Password must be atleast 8 characters")]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }


    }
}
