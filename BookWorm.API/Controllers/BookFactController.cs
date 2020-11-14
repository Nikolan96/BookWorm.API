using BookWorm.API.Requests;
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
    public class BookFactController : ControllerBase
    {
        private readonly IBookFactService _bookFactService;

        public BookFactController(IBookFactService bookFactService)
        {
            _bookFactService = bookFactService;
        }

        [HttpGet("{id}")]
        public ActionResult<BookFact> Get(Guid id)
        {
            var item = _bookFactService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookFact>> Get()
        {
            return Ok(_bookFactService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        [Route("GetWithPagination")]

        public ActionResult GetWithPagination(PaginationRequest request)
        {
            var list = _bookFactService.AsQueryable()
                   .Skip((request.Page - 1) * request.ItemsPerPage)
                   .Take(request.ItemsPerPage)
                   .ToList();

            return Ok(list);
        }

        [HttpPost]
        public ActionResult Post([FromBody] BookFact newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _bookFactService.AddBookFact(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] BookFact changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _bookFactService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _bookFactService.UpdateBookFact(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _bookFactService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _bookFactService.RemoveBookFact(item);

            return Ok();
        }
    }
}