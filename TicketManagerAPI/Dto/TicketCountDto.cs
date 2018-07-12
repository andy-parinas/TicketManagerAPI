using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Dto
{
    public class TicketCountDto
    {
        public int incidentTickets { get; set; }

        public int requestTickets { get; set; }

        public int changeTickets { get; set; }

        public int problemTickets { get; set; }

        public int userAssignedIncidents { get; set; }

        public int userAssignedRequests { get; set; }

        public int userAssignedChanges { get; set; }

        public int userAssignedProblems { get; set; }


    }
}
