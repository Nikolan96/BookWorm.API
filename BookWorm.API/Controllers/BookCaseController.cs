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
    public class BookCaseController : ControllerBase
    {
        private readonly IBookCaseService _bookAuthorService;

        public BookCaseController(IBookCaseService bookCaseService)
        {
            _bookAuthorService = bookCaseService;
        }

        [HttpGet("{id}")]
        public ActionResult<BookCase> Get(Guid id)
        {
            var item = _bookAuthorService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookCase>> Get()
        {
            return Ok(_bookAuthorService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        [Route("GetWithPagination")]

        public ActionResult GetWithPagination(PaginationRequest request)
        {
            var list = _bookAuthorService.AsQueryable()
                   .Skip((request.Page - 1) * request.ItemsPerPage)
                   .Take(request.ItemsPerPage)
                   .ToList();

            return Ok(list);
        }

        [HttpPost]
        public ActionResult Post([FromBody] BookCase newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _bookAuthorService.AddBookCase(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] BookCase changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _bookAuthorService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _bookAuthorService.UpdateBookCase(existingItem, changedItem);

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

            _bookAuthorService.RemoveBookCase(item);

            return Ok();
        }
    }
}