using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Dto
{
    public class JournalDetailDto
    {
        public int Id { get; set; }

        public string Entry { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}
