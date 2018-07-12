using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Dto
{
    public class JournalCreateDto
    {
        [Required]
        public string Entry { get; set; }

    }
}
