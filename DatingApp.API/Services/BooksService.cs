using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Database;
using DatingApp.API.Database.entities;
using DatingApp.API.DTOs;
using DatingApp.API.Interface;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Services
{
    public class BooksService : IBookService
    {
        private DataContext _context;
        public BooksService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddBookWithAuthors(BookDto bookdto)
        {
            if (bookdto == null) return -1;
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

                await _context.SaveChangesAsync();

                foreach (var id in bookdto.AuthorIds)
                {
                    var _book_author  = new Book_Author()
                    {
                        BookId = _book.Id,
                        AuthorId = id
                    };
                    _context.Book_Authors.Add(_book_author);
                    await _context.SaveChangesAsync();
                }

            return 1;
        }


        public async Task<IEnumerable<Book>> GetAllBooks() => await _context.Books.ToListAsync();

        public async Task<BookAuthorDto> GetBookById (int id)
        {
            var _bookAuthors = await _context.Books.Where(n => n.Id == id).Select(book => new BookAuthorDto()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()

            }).FirstOrDefaultAsync();
            return _bookAuthors;
        }

        public async Task<int> UpdateBookById(BookDto bookdto, int id)
        {
            var _book = await _context.Books.FirstOrDefaultAsync(n=> n.Id == id);
            if (_book == null) return -1;

            _book.Title = bookdto.Title;
            _book.Description = bookdto.Description;
            _book.IsRead = bookdto.IsRead;
            _book.DateRead = bookdto.IsRead ? bookdto.DateRead.Value : null;
            _book.Rate = bookdto.IsRead ? bookdto.Rate.Value : null;
            _book.Genre = bookdto.Genre;
            _book.CoverUrl = bookdto.CoverUrl;
            await _context.SaveChangesAsync();


            return _book.Id;
        }

        public async Task<int> DeleteBook (int id) 
        {
            var _book = _context.Books.FirstOrDefault(n=> n.Id == id);
            if (_book == null) return -1;
            _context.Books.Remove(_book);
            await _context.SaveChangesAsync();
            return _book.Id;
        }
    }

}