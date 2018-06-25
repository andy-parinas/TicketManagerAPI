using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Dto
{
    public class TicketCreateDto
    {

        [Required]
        public string Description { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public int CreatedById { get; set; }

        [Required]
        public int AssignedToId { get; set; }

        [Required]
        public int TicketTypeId { get; set; }

        [Required]
        public int TicketPriorityId { get; set; }

        [Required]
        public int TicketStatusId { get; set; }

        [Required]
        public int TicketQueueId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int ConfigItemId { get; set; }

    }
}
