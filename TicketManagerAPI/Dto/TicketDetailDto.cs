using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Dto
{
    public class TicketDetailDto
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public UserInfoDto CreatedBy { get; set; }

        public int AssignedToId { get; set; }

        public UserInfoDto AssignedTo { get; set; }

        public int TicketStatusId { get; set; }

        public string Status { get; set; }

        public int TicketPriorityId { get; set; }

        public string Priority { get; set; }

        public string TicketType { get; set; }

        public string Queue { get; set; }

        public ClientInfoDto Client { get; set; }

        public ConfigItemInfoDto ConfigItem { get; set; }

    }
}
