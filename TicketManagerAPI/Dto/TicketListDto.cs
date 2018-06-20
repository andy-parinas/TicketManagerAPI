using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Dto
{
    public class TicketListDto
    {
     
        public int Id { get; set; }

        public string Number { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public UserInfoDto CreatedBy { get; set; }

        public UserInfoDto AssignedTo { get; set; }
    }
}
