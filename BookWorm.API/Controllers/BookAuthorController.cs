using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        private readonly IBookAuthorService _bookAuthorService;

        public BookAuthorController(IBookAuthorService bookAuthorService)
        {
            _bookAuthorService = bookAuthorService;
        }

        [HttpGet("{id}")]
        public ActionResult<BookAuthor> Get(Guid id)
        {
            var item = _bookAuthorService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookAuthor>> Get()
        {
            return Ok(_bookAuthorService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] BookAuthor newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _bookAuthorService.AddBookAuthor(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] BookAuthor changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _bookAuthorService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _bookAuthorService.UpdateBookAuthor(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _bookAuthorService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _bookAuthorService.RemoveBookAuthor(item);

            return Ok();
        }
    }
}