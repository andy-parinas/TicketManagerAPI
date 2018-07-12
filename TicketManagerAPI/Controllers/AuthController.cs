﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TicketManagerAPI.Data;
using TicketManagerAPI.Dto;
using TicketManagerAPI.Models;

namespace TicketManagerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto register)
        {
            //VALIDATION

            if (await _repo.UserExist(register.Email))
                ModelState.AddModelError("Email", "Email already registered");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            User newUser = new User
            {
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Phone = register.Phone
            };

            User createdUser = await _repo.Register(newUser, register.Password);

            return StatusCode(201);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto login)
        {
            User user = await _repo.Login(login.Email, login.Password);

            if (user == null)
                return Unauthorized();

            //GENERATE TOKEN
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                                            SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var authUser = new
            {
                id = user.Id,
                name = user.FirstName
            };

            return Ok(new
            {
                user = authUser,
                token = tokenString
            });

        }
    }
}