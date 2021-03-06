﻿using System;
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

        //public DateTime CreatedAt { get; set; }

        public string CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public UserInfoDto CreatedBy { get; set; }

        public UserInfoDto AssignedTo { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public string TicketType { get; set; }

        public string Queue { get; set; }

        public string ClientName { get; set; }


    }
}
