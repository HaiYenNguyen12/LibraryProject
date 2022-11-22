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
public class AuthorsController : BaseApiController
{
    private readonly IAuthorService _authorsService;
    public AuthorsController(IAuthorService authorsSevice)
    {
        _authorsService = authorsSevice;
    }

    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPost]
    public async Task<IActionResult> AddAuthor(AuthorDto author)
    {
        var result = await _authorsService.AddAuthorAsync(author);
        return Ok(result);
    }

    //[HttpGet("{authorId}")]

    //public IActionResult GetAuthorWithBooks(int authorId)
    //{
    //    var _author = _authorsService.GetAuthorWithBooks(authorId);
    //    if (_author == null)
    //    {
    //        return NotFound("The author doesn't exist");
    //    }
    //    return Ok(_author);
    //}


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _authorsService.GetByIdAsync(id);
        return Ok(book);
    }
    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPut()]
    public async Task<IActionResult> UpdateAsync(int id, AuthorDto model)
    {
        var res = await _authorsService.UpdateAuthorAsync(id, model);
        if (res == -1) return BadRequest();
        return Ok(res);
    }
    [Authorize(Roles = RoleConstant.Admin)]
    [HttpDelete()]
    public async Task<IActionResult> DeletAsync(int id)
    {
        var res = await _authorsService.DeleteAuthorAsync(id);
        if (res == -1) return BadRequest();
        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await _authorsService.GetAllAsync();
        return Ok(res);
    }
}

