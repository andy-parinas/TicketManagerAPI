using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Dto
{
    public class TicketUpdateDto
    {
 
        public string Description { get; set; }
 
        public string Details { get; set; }

        public int AssignedToId { get; set; }

        public int TicketTypeId { get; set; }

        public int TicketPriorityId { get; set; }
  
        public int TicketStatusId { get; set; }
  
        public int TicketQueueId { get; set; }

        public int ClientId { get; set; }

        public int ConfigItemId { get; set; }
    }
}
