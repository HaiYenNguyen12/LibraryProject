using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Database;
using DatingApp.API.Database.entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Services
{
    public class UsersService
    {
        private DataContext _context;
        public UsersService(DataContext context)
        {
            _context = context;
        }
 
        public  UserWithBooksDto GetUserWithBooks (int UserId)
        {
            var _user = _context.Users.Where(n => n.Id == UserId).Select(n=> new UserWithBooksDto(){
                Username = n.Username,
                Email = n.Email,
                Role = n.Role,
                DateJoin = n.DateJoin,
                BookNames = n.Loans.Select(n=> n.Book.Title).ToList()
            }).FirstOrDefault();

            return _user;
        }


    }
}