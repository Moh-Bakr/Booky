using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booky.Data.Services;
using Booky.Data.ViewModels;
using Booky.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Booky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        
        private PublishersService _publishersService;
        private readonly ILogger<PublishersController> _logger;
        public PublishersController(PublishersService publishersService,ILogger<PublishersController> logger)
        {
            _publishersService = publishersService;
            _logger = logger;
        }
        
        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString)
        {
            try
            {
                _logger.LogInformation("This is just a log in GetAllPublishers()");
                var _result = _publishersService.GetAllPublishers(sortBy, searchString);
                return Ok(_result);
            }
            catch (Exception)
            {
                return BadRequest("Sorry, we could not load the publishers");
            }
        }
        [HttpPost("add-publisher")]
        public IActionResult  AddPublisher ([FromBody] PublisherVM publisher)
        {
            var newPublisher = _publishersService.AddPublisher(publisher);
            return Created(nameof(AddPublisher),newPublisher);
        }
        
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _publishersService.GetPublisherById(id);

            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }
        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}