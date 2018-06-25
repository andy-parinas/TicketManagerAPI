using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Dto
{
    public class ClientInfoDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string ClientType { get; set; }

    }
}
