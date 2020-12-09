using BookWorm.API.Dto;
using BookWorm.API.Extensions;
using BookWorm.API.Requests;
using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IAuthorService _authorService;
        private readonly IBookAuthorService _bookAuthorService;

        private Random _rnd = new Random();

        public BookController(IBookService bookService,
            IPickOfTheDayService pickOfTheDayService,
            IPickOfTheWeekService pickOfTheWeekService,
            IAuthorService authorService,
            IBookAuthorService bookAuthorService)
        {
            _bookService = bookService;
            _pickOfTheDayService = pickOfTheDayService;
            _pickOfTheWeekService = pickOfTheWeekService;
            _authorService = authorService;
            _bookAuthorService = bookAuthorService;
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> Get(Guid id)
        {
            BookDto book = new BookDto();

            var item = _bookService.AsQueryable()
                .Include(x => x.Publisher)
                .Include(x => x.Genre)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (item is null)
                return NoContent();

            book = MapToBookDto(item);

            return Ok(book);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            List<BookDto> bookDtos = new List<BookDto>();

            var books = _bookService
                .AsQueryable()
                .Include(x => x.Publisher)
                .Include(x => x.Genre)
                .ToList();

            foreach (var book in books)
            {
                bookDtos.Add(MapToBookDto(book));
            }

            return Ok(bookDtos);

        }

        [HttpGet]
        [Route("GetFiveBooksFromOfGenre/{bookId}")]
        public ActionResult<IEnumerable<BookDto>> GetFiveBooksFromOfGenre(Guid bookId)
        {
            var result = new List<BookDto>();

            var openedBook = _bookService
                .AsQueryable()
                .FirstOrDefault();

            if (openedBook is null)          
                return BadRequest($"Book with id : {bookId} does not exist!");
            
            var booksOfTheSameGenre = _bookService
                .AsQueryable()
                .Where(x => x.Id != bookId && x.GenreId == openedBook.GenreId)
                .Include(x => x.BookAuthors)
                .Include(x => x.Publisher)
                .Include(x => x.Genre)
                .ToList();

            booksOfTheSameGenre.Shuffle();

            var list = booksOfTheSameGenre.Take(5);

            foreach (var item in list)
            {
                result.Add(MapToBookDto(item));
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetFiveBooksFromSameAuthor/{bookId}")]
        public ActionResult<IEnumerable<BookDto>> GetFiveBooksFromSameAuthor(Guid bookId)
        {
            var result = new List<BookDto>();

            var openedBook = _bookService
                .AsQueryable()
                .Include(x => x.BookAuthors)
                .FirstOrDefault();

            if (openedBook is null)
                return BadRequest($"Book with id : {bookId} does not exist!");

            var authorId = openedBook.BookAuthors.FirstOrDefault().AuthorId;

            var idsOfAuthorsBooks = _bookAuthorService
                .AsQueryable()
                .Where(x => x.AuthorId == authorId)
                .Select(x => x.BookId)
                .ToList();

            idsOfAuthorsBooks.Shuffle();

            foreach (var id in idsOfAuthorsBooks.Take(5))
            {
                var book = _bookService
                    .AsQueryable()
                    .Include(x => x.BookAuthors)
                    .Include(x => x.Publisher)
                    .Include(x => x.Genre)
                    .FirstOrDefault(x => x.Id == id);

                result.Add(MapToBookDto(book));
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetPicksOfTheDay")]
        public ActionResult<IEnumerable<BookDto>> GetPicksOfTheDay()
        {
            List<BookDto> picksOfTheDay = new List<BookDto>();
            var bookIds = _pickOfTheDayService.AsQueryable().Select(x => x.BookId).ToList();

            foreach (var id in bookIds)
            {
                var book = _bookService
                     .AsQueryable()
                     .Include(x => x.Genre)
                     .Include(x => x.Publisher)
                     .Where(x => x.Id == id)
                     .FirstOrDefault();

                picksOfTheDay.Add(MapToBookDto(book));
            }

            return picksOfTheDay;
        }

        [HttpGet]
        [Route("GetPicksOfTheWeek")]
        public ActionResult<IEnumerable<BookDto>> GetPicksOfTheWeek()
        {
            List<BookDto> picksOfTheDay = new List<BookDto>();
            var bookIds = _pickOfTheWeekService.AsQueryable().Select(x => x.BookId).ToList();

            foreach (var id in bookIds)
            {
                var book = _bookService
                     .AsQueryable()
                     .Include(x => x.Genre)
                     .Include(x => x.Publisher)
                     .Where(x => x.Id == id)
                     .FirstOrDefault();

                picksOfTheDay.Add(MapToBookDto(book));
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

            var exists = _bookService.AsQueryable().Any(x => x.ISBN == newItem.ISBN);

            if (exists)
            {
                return BadRequest($"Book with ISBN : {newItem.ISBN} already exists!");
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


        private BookDto MapToBookDto(Book book)
        {
            var x = book.Id.ToString().ToUpper();
            Guid id = new Guid(book.Id.ToString().ToUpper());

            var bookAuthor = _bookAuthorService
                                .AsQueryable()
                                .Where(x => x.BookId == id)
                                .FirstOrDefault();

            var author = _authorService
                .AsQueryable()
                .Where(x => x.Id == bookAuthor.AuthorId)
                .FirstOrDefault();

            var bookDto = new BookDto
            {
                Id = book.Id,
                ISBN = book.ISBN,
                Author = $"{author.FirstName} {author.LastName}",
                Cover = book.Cover,
                Genre = book.Genre.Name,
                NumberOfPages = book.NumberOfPages,
                PublishDate = book.PublishDate,
                Publisher = book.Publisher.Name,
                Title = book.Title
            };
            return bookDto;
        }
    }
}
