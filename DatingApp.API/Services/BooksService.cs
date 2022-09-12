using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Database;
using DatingApp.API.Database.entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Services
{
    public class BooksService
    {
        private DataContext _context;
        public BooksService(DataContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookDto bookdto)
        {
                var _book = new Book(){
                    Title = bookdto.Title,
                    Description = bookdto.Description,
                    IsRead = bookdto.IsRead,
                    DateRead = bookdto.IsRead ? bookdto.DateRead.Value : null,
                    Rate = bookdto.IsRead ? bookdto.Rate.Value : null,
                    Genre = bookdto.Genre,
                    CoverUrl = bookdto.CoverUrl,
                    DateAdded = DateTime.Now,
                    PublisherId = bookdto.PublisherId
                
                };

                _context.Books.Add(_book);

                _context.SaveChanges();

                foreach (var id in bookdto.AuthorIds)
                {
                    var _book_author  = new Book_Author()
                    {
                        BookId = _book.Id,
                        AuthorId = id
                    };
                    _context.Book_Authors.Add(_book_author);
                    _context.SaveChanges();
                }
               
                

                 
                
        }


        public List<Book> GetAllBooks() => _context.Books.ToList();

        public BookAuthorDto GetBookById (int id)
        {
            var _bookAuthors = _context.Books.Where(n=> n.Id == id).Select(book => new BookAuthorDto(){
                    Title = book.Title,
                    Description = book.Description,
                    IsRead = book.IsRead,
                    DateRead = book.IsRead ? book.DateRead.Value : null,
                    Rate = book.IsRead ? book.Rate.Value : null,
                    Genre = book.Genre,
                    CoverUrl = book.CoverUrl,
                    PublisherName = book.Publisher.Name,
                    AuthorNames = book.Book_Authors.Select(n=> n.Author.FullName).ToList()

            }).FirstOrDefault();
            return _bookAuthors;
        }

        public Book UpdateBookById(BookDto bookdto, int id)
        {
            var _book = _context.Books.FirstOrDefault(n=> n.Id == id);
            if (_book != null){
                    _book.Title = bookdto.Title;
                    _book.Description = bookdto.Description;
                    _book.IsRead = bookdto.IsRead;
                    _book.DateRead = bookdto.IsRead ? bookdto.DateRead.Value : null;
                    _book.Rate = bookdto.IsRead ? bookdto.Rate.Value : null;
                    _book.Genre = bookdto.Genre;
                    _book.CoverUrl = bookdto.CoverUrl;
                    _context.SaveChanges();
            
            }
            return _book;
        }

        public void DeleteBook (int id) 
        {
            var _book = _context.Books.FirstOrDefault(n=> n.Id == id);
            if (_book != null) {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }


        }
    }

}