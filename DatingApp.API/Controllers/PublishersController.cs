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
public class PublishersController : BaseApiController
{
    private readonly IPublisherService _publishersService;
    public PublishersController(IPublisherService publishersService)
    {
        _publishersService = publishersService;
    }
    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPost]
    public async Task<IActionResult> AddPublisher(PublisherDto publisher)
    {
        var result = await _publishersService.AddPublisherAsync(publisher);
        return Ok(result);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _publishersService.GetByIdAsync(id);
        return Ok(book);
    }
    [Authorize(Roles = RoleConstant.Admin)]
    [HttpPut()]
    public async Task<IActionResult> UpdateAsync(int id, PublisherDto model)
    {
        var res = await _publishersService.UpdatePublisherAsync(id, model);
        if (res == -1) return BadRequest();
        return Ok(res);
    }
    [Authorize(Roles = RoleConstant.Admin)]
    [HttpDelete()]
    public async Task<IActionResult> DeletAsync(int id)
    {
        var res = await _publishersService.DeleteAsync(id);
        if (res == -1) return BadRequest();
        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await _publishersService.GetAllAsync();
        return Ok(res);
    }
    //[HttpPost]
    //public IActionResult AddPublisher([FromBody] PublisherDto publisherdto)
    //{
    //    _publishersService.AddPublish(publisherdto);
    //    return Ok();
    //}


    //[HttpGet("{id}")]
    //    public  ActionResult  GetPublisherData(int id)
    //    {
    //       var _data = _publishersService.GetPublisherData(id);
    //       if (_data == null) 
    //       {
    //        return NotFound("The publisher doesn't exist.");
    //       }
    //       return Ok(_data);

    //        // return Ok(await _context.Songs.ToListAsync());
    //    }

    //    [HttpDelete("{id}")]
    //    public IActionResult DeletePublisherById(int id)
    //    {
    //        _publishersService.DeletePublisherById(id);
    //        return Ok();
    //    }

}