using DatingApp.API.DTOs;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublishersController : BaseApiController
{
    private PublishersService _publishersService;
    public PublishersController(PublishersService publishersService)
    {
        _publishersService = publishersService;
    }


    [HttpPost]
    public IActionResult AddPublisher([FromBody] PublisherDto publisherdto)
    {
        _publishersService.AddPublish(publisherdto);
        return Ok();
    }


    [HttpGet("{id}")]
        public  ActionResult  GetPublisherData(int id)
        {
           var _data = _publishersService.GetPublisherData(id);
           if (_data == null) 
           {
            return NotFound("The publisher doesn't exist.");
           }
           return Ok(_data);

            // return Ok(await _context.Songs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publishersService.DeletePublisherById(id);
            return Ok();
        }

}