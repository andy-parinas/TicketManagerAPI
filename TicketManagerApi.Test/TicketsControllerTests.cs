using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagerAPI.Controllers;
using TicketManagerAPI.Data;
using TicketManagerAPI.Dto;
using TicketManagerAPI.Helpers;
using TicketManagerAPI.Models;
using Xunit;

namespace TicketManagerApi.Test
{
    
    public class TicketsControllerTests
    {
        [Fact]
        public async Task VerifyGetTickets()
        {

            //Arange 
            var tickets = new List<Ticket>
            {
                new Ticket
                {
                    Id = 1,
                    Number = "INC123456",
                    Description = "This is a test Ticket",
                    Details = "Test Ticket Details",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedById = 1,
                    AssignedToId = 1,
                    TicketTypeId = 1,
                    TicketPriorityId = 1,
                    TicketStatusId = 1,
                    TicketQueueId =1,
                    ClientId =1,
                    ConfigItemId = 1,

                },
                new Ticket
                {
                    Id = 1,
                    Number = "INC123456",
                    Description = "This is a test Ticket",
                    Details = "Test Ticket Details",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedById = 1,
                    AssignedToId = 1,
                    TicketTypeId = 1,
                    TicketPriorityId = 1,
                    TicketStatusId = 1,
                    TicketQueueId =1,
                    ClientId =1,
                    ConfigItemId = 1,

                }

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Ticket>>();
         
            mockSet.As<IAsyncEnumerable<Ticket>>().Setup(m => m.GetEnumerator())
                .Returns(new TestAsyncEnumerator<Ticket>(tickets.GetEnumerator()));

            mockSet.As<IQueryable<Ticket>>().Setup(m => m.Provider)
              .Returns(new TestAsyncQueryProvider<Ticket>(tickets.Provider));

            mockSet.As<IQueryable<Ticket>>().Setup(m => m.Expression).Returns(tickets.Expression);
            mockSet.As<IQueryable<Ticket>>().Setup(m => m.ElementType).Returns(tickets.ElementType);
            mockSet.As<IQueryable<Ticket>>().Setup(m => m.GetEnumerator()).Returns(tickets.GetEnumerator());

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Tickets).Returns(mockSet.Object);

            var ticketRepo = new TicketRepository(mockContext.Object);
            var userRepo = new Mock<IUsersRepository>();
            var clientRepo = new Mock<IClientRepository>();
            var mapper = new Mock<IMapper>();
            var controller = new TicketsController(ticketRepo, mapper.Object,
                                userRepo.Object, clientRepo.Object);

            var ticketParams = new TicketParams();

            //Act
            var actionResult = await controller.GetTickets(ticketParams);
            var repoResult = await ticketRepo.GetTickets(ticketParams);

            //Assert
            var okResult = actionResult.Should().BeOfType<OkObjectResult>().Subject;
            var ticketResult = okResult.Value.Should().BeAssignableTo<ICollection<TicketListDto>>().Subject;
            Assert.Equal(3, repoResult.Count);
            
        }
    }
}

