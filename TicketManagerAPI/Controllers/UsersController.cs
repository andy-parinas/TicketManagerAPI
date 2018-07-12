using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagerAPI.Data;
using TicketManagerAPI.Dto;

namespace TicketManagerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {

        private readonly IUsersRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            if (user == null)
                return NotFound();

            var userToReturn = _mapper.Map<UserDetailDto>(user);

            return Ok(userToReturn);


        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var users = await _repo.GetUsers();

            var usersToReturn = _mapper.Map<ICollection<UserListDto>>(users);


            return Ok(usersToReturn);

                

        }
    }
}