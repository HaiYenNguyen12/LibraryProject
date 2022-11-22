using DatingApp.API.Database.entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Interface
{
    public interface IBookService
    {
        Task<int> AddBookWithAuthors(BookDto bookdto);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<BookAuthorDto> GetBookById(int id);
        Task<int> DeleteBook(int id);
        Task<int> UpdateBookById(BookDto bookdto, int id);
    }
}
