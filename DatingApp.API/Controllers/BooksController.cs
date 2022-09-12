using DatingApp.API.DTOs;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : BaseApiController
{
    private BooksService _booksService;
    public BooksController(BooksService booksSevice)
    {
        _booksService = booksSevice;
    }


    [HttpPost]
    public IActionResult AddBook([FromBody] BookDto book)
    {
        _booksService.AddBookWithAuthors(book);
        return Ok();
    }

    [HttpGet]

    public IActionResult GetBooks()
    {
       var allBooks =  _booksService.GetAllBooks();
       return Ok(allBooks);
    }

    
    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
       var book =  _booksService.GetBookById(id);
       if (book  == null) {
        return NotFound("The book doesn't exist");
       }
       return Ok(book);
    }
   

   
    [HttpPut("{id}")]
    public IActionResult UpdateBookById(int id, [FromBody] BookDto book)
    {
        var book_updated = _booksService.UpdateBookById(book, id);
        if (book_updated == null) {
            return NotFound("Not found book to update");
        }
        return Ok(book_updated);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBookById(int id)
    {
        _booksService.DeleteBook(id);
        return Ok();
    }
   
}

// using DatingApp.API.Database;
// using DatingApp.API.Database.entities;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace DatingApp.API.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class SongController : BaseApiController
//     {
//         private readonly DataContext _context;
//         public SongController(DataContext context)
//         {
//             _context = context;
//         }
//         [HttpGet]
//         public async Task<ActionResult<List<Song>>>  GetSongs()
//         {
            
//             return Ok(await _context.Songs
//             .ToListAsync());
//         }

//         [HttpPost]
//         public async Task<ActionResult<List<Song>>> CreateSong(Song song)
//         {
//             _context.Songs.Add(song);
//             await _context.SaveChangesAsync();
//             return Ok(await _context.Songs.ToListAsync());
        
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<List<Song>>>  GetSong(int id)
//         {
//             var song = await _context.Songs.FirstOrDefaultAsync(u => u.Id == id);
//             if (song == null) {
//                 return NotFound("This song doesn't exist.");
//             }
//             return Ok(song);

//             // return Ok(await _context.Songs.ToListAsync());
//         }

//         [HttpPut("{id}")]
//         public async Task<ActionResult<List<Song>>> UpdateSong (Song song , int id)
//         {
//             var song_old = await _context.Songs.FirstOrDefaultAsync(u => u.Id == id);
//             if (song_old == null) {
//                 return NotFound("This song doesn't exist.");
//             }
//                 song_old.Name = song.Name;
//                 song_old.Singer = song.Singer;
//                 song_old.Author = song.Author;
//                 song_old.favorite = song.favorite;
//                 song_old.Price = song.Price;
//                 song_old.Playlists = song.Playlists;
//                 song_old.RemarkablePoint  =  song.RemarkablePoint;
//                 song_old.RemarkablePointId = song.RemarkablePointId;

//                 await _context.SaveChangesAsync();
//                 return Ok(await _context.Songs.ToListAsync());
//         }

//         [HttpDelete("{id}")]
//         public async Task<ActionResult<List<Song>>>  DeleteSong(int id)
//         {
//             var song = await _context.Songs.FirstOrDefaultAsync(u => u.Id == id);
//             if (song == null) {
//                 return NotFound("This song doesn't exist.");
//             }
//             _context.Songs.Remove(song);

//             await _context.SaveChangesAsync();

//              return Ok(await _context.Songs.ToListAsync());

//             // return Ok(await _context.Songs.ToListAsync());
//         }

//     }



// }