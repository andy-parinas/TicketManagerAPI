﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagerAPI.Helpers;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Data
{
    public interface ITicketRepository
    {


        Task<PageList<Ticket>> GetTickets(TicketParams ticketParams);

        Task<Ticket> GetTicket();

        Task<bool> Save();

        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

    }
}