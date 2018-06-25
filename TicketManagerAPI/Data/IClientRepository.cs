using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Data
{
    public interface IClientRepository
    {

        Task<Client> GetClient(int id);

        Task<ConfigItem> GetConfigItem( int configItemId);



    }
}
