using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagerAPI.Data;
using TicketManagerAPI.Dto;
using TicketManagerAPI.Helpers;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tickets")]
    public class TicketsController : Controller
    {

        private readonly ITicketRepository _repo;
        private readonly IUsersRepository _userRepo;
        private readonly IClientRepository _clientRepo;
        private readonly IMapper _mapper;

        public TicketsController(ITicketRepository repo, IMapper mapper, IUsersRepository userRepo, IClientRepository clientRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _userRepo = userRepo;
            _clientRepo = clientRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets([FromQuery] TicketParams ticketParams)
        {
            var tickets = await _repo.GetTickets(ticketParams);

            var ticketsToReturn = _mapper.Map<IEnumerable<TicketListDto>>(tickets);

            Response.AddPagination(tickets.CurrentPage, tickets.PageSize, tickets.TotalCount, tickets.TotalPages);

            return Ok(ticketsToReturn);
        }

        [HttpGet("{id}", Name = "GetTicket")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _repo.GetTicket(id);

            if (ticket == null)
                return NotFound();

            var ticketToReturn =  _mapper.Map<TicketDetailDto>(ticket);

            return Ok(ticketToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketCreateDto ticketCreate)
        {

            User createdBy =  await _userRepo.GetUser(ticketCreate.CreatedById);

            if (createdBy == null)
                ModelState.AddModelError("CreatedBy", "User does not exist");

            User assignedTo = await _userRepo.GetUser(ticketCreate.AssignedToId);

            if (assignedTo == null)
                ModelState.AddModelError("AssignedTo", "User does not exist");

            Client client = await _clientRepo.GetClient(ticketCreate.ClientId);

            if (client == null)
                ModelState.AddModelError("Client", "Client does not exist");

            ConfigItem item = await _clientRepo.GetConfigItem(ticketCreate.ConfigItemId);

            if (item == null)
                ModelState.AddModelError("Config Item", "Configuration Item does not exist");

            TicketPriority priority = await _repo.GetTicketPriority(ticketCreate.TicketPriorityId);

            if (priority == null)
                ModelState.AddModelError("Ticket Priority", "Priority does not exist");

            TicketStatus status = await _repo.GetTicketStatus(ticketCreate.TicketStatusId);

            if (status == null)
                ModelState.AddModelError("Ticket Status", "Ticket Status does not exist");

            TicketType type = await _repo.GetTicketType(ticketCreate.TicketTypeId);

            if (type == null)
                ModelState.AddModelError("Ticket Type", "Ticket Type does not exisit");

            TicketQueue queue = await _repo.GetTicketQueue(ticketCreate.TicketQueueId);

            if (queue == null)
                ModelState.AddModelError("Queue", "Ticket Queue does not exisit");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var createdAt = DateTime.Now;
            var updatedAt = DateTime.Now;


            Ticket newTicket = new Ticket
            {
                Description = ticketCreate.Description,
                Details = ticketCreate.Details,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt,
                AssignedTo = assignedTo,
                CreatedBy = createdBy,
                TicketPriority = priority,
                TicketStatus = status,
                TicketType = type,
                TicketQueue = queue,
                Client = client,
                ConfigItem = item
            };

            _repo.Create(newTicket);

            if (await _repo.Save())
            {
                var ticketToReturn = _mapper.Map<TicketDetailDto>(newTicket);

                return CreatedAtRoute("GetTicket", new {controller="Tickets", id=newTicket.Id }, ticketToReturn);
            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketUpdateDto ticketUpdate)
        {

            Ticket ticket = await _repo.GetTicket(id);

            if (ticket == null)
                return NotFound();

            if (!string.IsNullOrEmpty(ticketUpdate.Description) || !string.IsNullOrWhiteSpace(ticketUpdate.Description))
            {
                ticket.Description = ticketUpdate.Description;
            }

            if (!string.IsNullOrEmpty(ticketUpdate.Details) || !string.IsNullOrWhiteSpace(ticketUpdate.Details))
            {
                ticket.Details = ticketUpdate.Details;
            }

            if(ticketUpdate.AssignedToId > 0)
            {
                User user = await _userRepo.GetUser(ticketUpdate.AssignedToId);

                if (user == null)
                    return BadRequest(new { error = "User not found" });

                ticket.AssignedTo = user;
            }

            if (ticketUpdate.TicketStatusId > 0)
            {
                TicketStatus status = await _repo.GetTicketStatus(ticketUpdate.TicketStatusId);

                if (status == null)
                    return BadRequest(new { error = "status not found" });

                ticket.TicketStatus = status;
            }


            if (ticketUpdate.TicketPriorityId > 0)
            {
                TicketPriority priority = await _repo.GetTicketPriority(ticketUpdate.TicketPriorityId);

                if (priority == null)
                    return BadRequest(new { error = "priority not found" });

                ticket.TicketPriority = priority;
            }

            if (ticketUpdate.TicketTypeId > 0)
            {
                TicketType type = await _repo.GetTicketType(ticketUpdate.TicketTypeId);

                if (type == null)
                    return BadRequest(new { error = "Ticket Type not found" });

                ticket.TicketType = type;
            }

            if (ticketUpdate.TicketQueueId > 0)
            {
                TicketQueue queue = await _repo.GetTicketQueue(ticketUpdate.TicketQueueId);

                if (queue == null)
                    return BadRequest(new { error = "Ticket Queue not found" });

                ticket.TicketQueue = queue;
            }

            if (ticketUpdate.ClientId > 0)
            {
                Client client = await _clientRepo.GetClient(ticketUpdate.ClientId);

                if (client == null)
                    return BadRequest(new { error = "Ticket Client not found" });

                ticket.Client = client;
            }

            if (ticketUpdate.ConfigItemId > 0)
            {
                ConfigItem item = await _clientRepo.GetConfigItem(ticketUpdate.ConfigItemId);

                if (item == null)
                    return BadRequest(new { error = "Ticket Config Item not found" });

                ticket.ConfigItem = item;
            }


            ticket.UpdatedAt = DateTime.Now;

            if (await _repo.Save())
            {
                var ticketToReturn = _mapper.Map<TicketDetailDto>(ticket);

                return Ok(ticketToReturn);
            }


            return BadRequest(new {error = "Ticket cannot be saved" });


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            Ticket ticket = await _repo.GetTicket(id);

            if (ticket == null)
                return NotFound();

            _repo.Delete(ticket);

            if (await _repo.Save())
                return Ok();


            return BadRequest(new { error = "Error Deleting Ticket" });

        }


    }
}