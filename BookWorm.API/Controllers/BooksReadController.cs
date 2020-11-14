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
    public class BooksReadController : ControllerBase
    {
        private readonly IBooksReadService _booksReadService;

        public BooksReadController(IBooksReadService booksReadService)
        {
            _booksReadService = booksReadService;
        }

        [HttpGet("{id}")]
        public ActionResult<BooksRead> Get(Guid id)
        {
            var item = _booksReadService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BooksRead>> Get()
        {
            return Ok(_booksReadService
                .AsQueryable()
                .ToList());
        }

        [HttpPost]
        [Route("GetWithPagination")]

        public ActionResult GetWithPagination(PaginationRequest request)
        {
            var list = _booksReadService.AsQueryable()
                   .Skip((request.Page - 1) * request.ItemsPerPage)
                   .Take(request.ItemsPerPage)
                   .ToList();

            return Ok(list);
        }

        [HttpPost]
        public ActionResult Post([FromBody] BooksRead newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var exists = _booksReadService
                .AsQueryable()
                .Where(x => x.BookId == newItem.BookId && x.UserId == newItem.UserId)
                .FirstOrDefault();

            if (exists != null)
            {
                return BadRequest("You already read that book!");
            }

            var item = _booksReadService.AddBooksRead(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] BooksRead changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _booksReadService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _booksReadService.UpdateBooksRead(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _booksReadService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _booksReadService.RemoveBooksRead(item);

            return Ok();
        }
    }
}
