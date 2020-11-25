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
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IPickOfTheDayService _pickOfTheDayService;
        private readonly IPickOfTheWeekService _pickOfTheWeekService;

        public BookController(IBookService bookService,
            IPickOfTheDayService pickOfTheDayService,
            IPickOfTheWeekService pickOfTheWeekService)
        {
            _bookService = bookService;
            _pickOfTheDayService = pickOfTheDayService;
            _pickOfTheWeekService = pickOfTheWeekService;
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(Guid id)
        {
            var item = _bookService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Ok(_bookService
                .AsQueryable()
                .ToList());
        }

        [HttpGet]
        [Route("GetPicksOfTheDay")]
        public ActionResult<IEnumerable<Book>> GetPicksOfTheDay()
        {
            List<Book> picksOfTheDay = new List<Book>();
            var bookIds = _pickOfTheDayService.AsQueryable().Select(x => x.BookId).ToList();

            foreach (var id in bookIds) 
            {
               var book = _bookService
                    .AsQueryable()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                picksOfTheDay.Add(book);
            }

            return picksOfTheDay;
        }

        [HttpGet]
        [Route("GetPicksOfTheWeek")]
        public ActionResult<IEnumerable<Book>> GetPicksOfTheWeek()
        {
            List<Book> picksOfTheDay = new List<Book>();
            var bookIds = _pickOfTheWeekService.AsQueryable().Select(x => x.BookId).ToList();

            foreach (var id in bookIds)
            {
                var book = _bookService
                     .AsQueryable()
                     .Where(x => x.Id == id)
                     .FirstOrDefault();

                picksOfTheDay.Add(book);
            }

            return picksOfTheDay;
        }

        [HttpPost]
        [Route("GetWithPagination")]
        public ActionResult GetWithPagination(PaginationRequest request)
        {
            if (request.Page <= 0)
            {
                return BadRequest("Page cannot be 0 or less than 0!");
            }

            if (request.ItemsPerPage <= 0)
            {
                return BadRequest("Items per page cannot be 0 or less than 0!");
            }

            var list = _bookService.AsQueryable()
                   .Skip((request.Page - 1) * request.ItemsPerPage)
                   .Take(request.ItemsPerPage)
                   .ToList();

            return Ok(list);
        }

        [HttpGet]
        [Route("GetNumberOfPages/{itemsPerPage}")]
        public ActionResult GetNumberOfPages(double itemsPerPage)
        {
            if (itemsPerPage <= 0)
            {
                return BadRequest("Items per page cannot be 0 or less than 0!");
            }

            double totalItems = _bookService.AsQueryable().ToList().Count;

            double res = totalItems / itemsPerPage;

            if (!((res % 1) == 0))
            {
               res = Math.Ceiling(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Book newItem)
        {
            if (newItem is null)
            {
                return BadRequest();
            }

            var item = _bookService.AddBook(newItem);

            return Ok(item);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Book changedItem)
        {
            if (changedItem is null)
                return BadRequest();

            var existingItem = _bookService.AsQueryable()
                .Where(x => x.Id == changedItem.Id)
                .FirstOrDefault();

            if (existingItem is null)
                return NotFound();

            var item = _bookService.UpdateBook(existingItem, changedItem);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _bookService.AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NotFound();

            _bookService.RemoveBook(item);

            return Ok();
        }
    }
}
