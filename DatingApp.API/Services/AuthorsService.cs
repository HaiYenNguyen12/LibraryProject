using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Database;
using DatingApp.API.Database.entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Services
{
    public class AuthorsService
    {
        private DataContext _context;
        public AuthorsService(DataContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorDto authordto)
        {
            var _author = new Author(){
                    FullName = authordto.FullName
                };
                _context.Authors.Add(_author);
                _context.SaveChanges();
        }

        public AuthorWithBookDto GetAuthorWithBooks (int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n=> new AuthorWithBookDto(){
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n=> n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }


    }
}