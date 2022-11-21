using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Controllers;
using DatingApp.API.Database;
using DatingApp.API.Database.entities;
using DatingApp.API.DTOs;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private const string V = "admin";
        private const string Y = "user";
        private readonly UsersService  _usersService;
        public readonly DataContext _context;
        

        public UserController (DataContext context, UsersService  usersService){
            _context = context;
            _usersService   = usersService;
        }

        [Authorize(Roles= V)]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_context.Users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<UserWithBooksDto> Get(int id) 
        {
            // var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var user = _usersService.GetUserWithBooks(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }
         
    }
}