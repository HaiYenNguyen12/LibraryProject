using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Database;
using DatingApp.API.Database.entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Services
{
    public class PublishersService
    {
        private DataContext _context;
        public PublishersService(DataContext context)
        {
            _context = context;
        }
        public void AddPublish(PublisherDto publishdto)
        {
            var _publisher = new Publisher(){
                    Name = publishdto.Name
                };
                _context.Publishers.Add(_publisher);
                _context.SaveChanges();
        }

        public PublisherWithBooksandAuthorsDto GetPublisherData (int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n=> n.Id == publisherId)
                                        .Select( n => new PublisherWithBooksandAuthorsDto(){
                                            Name = n.Name,
                                            BookAuthors = n.Books.Select(n => new BookWithAuthorDto()
                                            {
                                                BookName = n.Title,
                                                BookAuthors = n.Book_Authors.Select(n=>n.Author.FullName).ToList()
                                            }).ToList()

                                        }).FirstOrDefault();
            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
           var _publisher =  _context.Publishers.FirstOrDefault(n=> n.Id == id);
           if (_publisher != null) 
           {
            _context.Publishers.Remove(_publisher);
            _context.SaveChanges();
           } 
        }
    }
}