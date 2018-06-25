using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagerAPI.Models
{
    public class ConfigItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ConfigItemTypeId { get; set; }

        public ConfigItemType ConfigItemType { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
