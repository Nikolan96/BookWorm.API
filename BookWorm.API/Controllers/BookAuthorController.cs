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
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public BookAuthorController(IBookAuthorService bookAuthorService,
            IAuthorService authorService,
            IBookService bookService)
        {
            _bookAuthorService = bookAuthorService;
            _authorService = authorService;
            _bookService = bookService;
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

        [HttpGet]
        [Route("RandomlyGenerateBookAuthors")]
        public ActionResult RandomlyGenerateBookAuthors()
        {
            var authors = _authorService.AsQueryable().ToList();
            var books = _bookService.AsQueryable().ToList();
            Random rnd = new Random();
            for (int i = 0; i < books.Count; i++)
            {
                BookAuthor bookAuthor = new BookAuthor
                {
                    AuthorId = authors[rnd.Next(0, authors.Count - 1)].Id,
                    BookId = books[i].Id
                };
                _bookAuthorService.AddBookAuthor(bookAuthor);
            }

            return Ok();
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