using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Helpers
{
    public class TicketParams
    {
        private const int MAX_PAGE_SIZE = 50;

        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value); }
        }

        public int AssignedTo { get; set; } = 0;

        public int CreatedBy { get; set; } = 0;

        public string Filter { get; set; }

        public string Sort { get; set; } = "CreatedAt";

        public string Direction { get; set; } = "ASC";

        public int TicketTypeId { get; set; } = 0;

        public string TicketType { get; set; }

        public int TicketPriorityId { get; set; } = 0;

        public string TicketPriority { get; set; }

        public int TicketQueueId { get; set; } = 0;

        public string TicketQueue { get; set; }

        public int TicketStatusId { get; set; } = 0;

        public string TicketStatus { get; set; }
    }
}
