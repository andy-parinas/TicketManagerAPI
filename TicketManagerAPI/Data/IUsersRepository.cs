using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagerAPI.Helpers;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Data
{
    public interface IUsersRepository
    {

        Task<User> GetUser(int id);

        Task<ICollection<User>> GetUsers();

        Task<bool> Save();
    }
}
