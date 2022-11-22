using DatingApp.API.Constant;
using DatingApp.API.DTOs;
using DatingApp.API.Interface;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DatingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : BaseApiController
{
    private readonly IBookService _booksService;
    public BooksController(IBookService booksSevice)
    {
        _booksService = booksSevice;
    }

    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookDto book)
    {
       var res = await _booksService.AddBookWithAuthors(book);
        return Ok(res);
    }

    [HttpGet]

    public async Task<IActionResult>  GetBooks()
    {
        var allBooks =  await _booksService.GetAllBooks();
        return Ok(allBooks);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _booksService.GetBookById(id);
        if (book == null)
        {
            return NotFound("The book doesn't exist");
        }
        return Ok(book);
    }



    [HttpPut()]
    public async Task<IActionResult> UpdateBookById(int id, [FromBody] BookDto book)
    {
        var res = await _booksService.UpdateBookById(book,id);
        
        return Ok(res);
    }

    [HttpDelete()]
    public async Task<IActionResult> DeleteBookById(int id)
    {
        var res =  await _booksService.DeleteBook(id);
        return Ok(res);
    }

}

