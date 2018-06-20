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

        Task<PageList<User>> GetUsers(UserParams userParams);

        Task<bool> Save();
    }
}
