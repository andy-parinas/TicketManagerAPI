using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagerAPI.Helpers;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Data
{
    public class UsersRepository : IUsersRepository
    {

        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(u => u.CreatedTickets).Include(u => u.AssignedTickets)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            ICollection<User> users = await _context.Users.ToListAsync();

            return users;
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}
