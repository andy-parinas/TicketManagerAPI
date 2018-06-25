using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Data
{
    public class ClientRepository : IClientRepository
    {

        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClient(int id)
        {
            Client client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            return client;
        }

        public async Task<ConfigItem> GetConfigItem( int configItemId)
        {
            ConfigItem configItem = await _context.ConfigItems.FirstOrDefaultAsync(c => c.Id == configItemId);

            return configItem;
        }

   
    }
}
