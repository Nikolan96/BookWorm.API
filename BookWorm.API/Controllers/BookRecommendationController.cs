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
    public class BookRecommendationController : ControllerBase
    {
        private readonly IBooksReadService _booksReadService;
        private readonly IUserOpenedBookPageService _userOpndBookPageService;
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        private readonly IBookAuthorService _bookAuthorService;
        private readonly IAuthorService _authorService;
        List<Guid> _bookIds = new List<Guid>();
        List<Book> _allBooks = new List<Book>();
        List<Book> _recommendedBooks = new List<Book>();
        List<BooksRead> _booksUserRead = new List<BooksRead>();
        List<Book> _booksUserReadOrViewed = new List<Book>();
        List<Book> _favGenreBooksNotReadByUser = new List<Book>(); 
        List<Book> _booksFromFavAuthorUserHasNotYetRead = new List<Book>();
        Random _rnd = new Random();

        public BookRecommendationController(IBooksReadService booksReadService,
            IUserOpenedBookPageService userOpenedBookPageService,
            IBookService bookService,
            IGenreService genreService,
            IBookAuthorService bookAuthorService,
            IAuthorService authorService)
        {
            _booksReadService = booksReadService;
            _userOpndBookPageService = userOpenedBookPageService;
            _bookService = bookService;
            _genreService = genreService;
            _bookAuthorService = bookAuthorService;
            _authorService = authorService;
        }

        [HttpGet("GetRecommendations/{userId}")]
        public ActionResult<List<Book>> Get(Guid userId)
        {
            // Gets all book pages user viewed and all books user has read.
            GetBooksUserHasReadOrViewed(userId);
            GetRecommendationsForFavGenre();
            GetAuthorRecommendations();

            // 3 recommendations for fav genre
            for (int i = 0; i < 3; i++)
            {
                var rndBook = _favGenreBooksNotReadByUser[_rnd.Next(0, _favGenreBooksNotReadByUser.Count - 1)];
                _recommendedBooks.Add(
                    new Book
                    {
                        Id = rndBook.Id,
                        ISBN = rndBook.ISBN,
                        GenreId = rndBook.GenreId,
                        Title = rndBook.Title,
                        PublishDate = rndBook.PublishDate,
                        Cover = rndBook.Cover
                    });
            }

            //2 recommendations from fav author
            for (int i = 0; i < 2; i++)
            {
                var rndBook = _booksFromFavAuthorUserHasNotYetRead[_rnd.Next(0, _booksFromFavAuthorUserHasNotYetRead.Count - 1)];

                if (!_recommendedBooks.Contains(rndBook))
                {
                    _recommendedBooks.Add(
                  new Book
                  {
                      Id = rndBook.Id,
                      ISBN = rndBook.ISBN,
                      GenreId = rndBook.GenreId,
                      Title = rndBook.Title,
                      PublishDate = rndBook.PublishDate,
                      Cover = rndBook.Cover
                  });
                }
            }

            return Ok(_recommendedBooks);
        }

        [HttpGet("BooksByGenreRecommendation/{userId}")]
        public ActionResult<List<Book>> BooksByGenreRecommendation(Guid userId)
        {
            // Gets all book pages user viewed and all books user has read.
            GetBooksUserHasReadOrViewed(userId);
            GetRecommendationsForFavGenre();

            // 5 recommendations for fav genre
            for (int i = 0; i < 5; i++)
            {
                var rndBook = _favGenreBooksNotReadByUser[_rnd.Next(0, _favGenreBooksNotReadByUser.Count - 1)];
                _recommendedBooks.Add(
                    new Book
                    {
                        Id = rndBook.Id,
                        ISBN = rndBook.ISBN,
                        GenreId = rndBook.GenreId,
                        Title = rndBook.Title,
                        PublishDate = rndBook.PublishDate,
                        Cover = rndBook.Cover
                    });
            }

            return Ok(_recommendedBooks);
        }

        [HttpGet("AuthorBooksRecommendation/{userId}")]
        public ActionResult<List<Book>> AuthorBooksRecommendation(Guid userId)
        {
            // Gets all book pages user viewed and all books user has read.
            GetBooksUserHasReadOrViewed(userId);
            GetAuthorRecommendations();

            while (_recommendedBooks.Count < 5)
            {
                var rndBook = _booksFromFavAuthorUserHasNotYetRead[_rnd.Next(0, _booksFromFavAuthorUserHasNotYetRead.Count - 1)];

                if (!_recommendedBooks.Contains(rndBook))
                {
                    _recommendedBooks.Add(
                  new Book
                  {
                      Id = rndBook.Id,
                      ISBN = rndBook.ISBN,
                      GenreId = rndBook.GenreId,
                      Title = rndBook.Title,
                      PublishDate = rndBook.PublishDate,
                      Cover = rndBook.Cover
                  });
                }
            }

            return Ok(_recommendedBooks);
        }

        [HttpGet("PickOfTheWeek")]
        public ActionResult<List<Book>> PickOfTheWeek()
        {
            var booksRead = _userOpndBookPageService
                .AsQueryable()
                .Distinct()
                .ToList();

            return Ok();
        } 

        private void GetBooksUserHasReadOrViewed(Guid userId)
        {
            var bookPagesUserOpened = _userOpndBookPageService
                    .AsQueryable()
                    .Where(x => x.UserId == userId)
                    .ToList();

            _booksUserRead = _booksReadService
                    .AsQueryable()
                    .Include(x => x.Book)
                    .Where(x => x.UserId == userId)
                    .ToList();

            GetBookIdsWhichUserViewedOrRead(bookPagesUserOpened, _booksUserRead);

            _allBooks = _bookService
                    .AsQueryable()
                    .Include(x => x.Genre)
                    .Include(x => x.BookAuthors)
                    .ToList();

            foreach (var id in _bookIds)
            {
                _booksUserReadOrViewed.Add(_allBooks
                    .AsQueryable()
                    .Include(x => x.Genre)
                    .Include(x => x.BookAuthors)
                    .Where(x => x.Id == id)
                    .FirstOrDefault());
            }
        }

        private void GetRecommendationsForFavGenre()
        {
            var groupedByGenre = _booksUserReadOrViewed
                .GroupBy(x => x.Genre)
                .Select(x => new GroupingByGenre
                {
                    Id = x.Key.Id,
                    GenreName = x.Key.Name,
                })
                .ToList();

            foreach (var grouping in groupedByGenre)
            {
                foreach (var book in _booksUserReadOrViewed)
                {
                    if (grouping.Id == book.GenreId)
                    {
                        grouping.NumOfBooks++;
                    }
                }
            }

            var favGenreId = groupedByGenre.OrderByDescending(x => x.NumOfBooks).First().Id;

            var favGenreBooks = _allBooks.AsQueryable().Where(x => x.GenreId == favGenreId).ToList();

            foreach (var favGenreBook in favGenreBooks)
            {
                foreach (var bookUserRead in _booksUserRead)
                {
                    if (favGenreBook.Id != bookUserRead.Id)
                    {
                        _favGenreBooksNotReadByUser.Add(favGenreBook);
                    }
                }
            }
        }

        private void GetBookIdsWhichUserViewedOrRead(List<UserOpenedBookPage> bookPagesUserOpened, List<BooksRead> booksUserRead)
        {
            foreach (var bookPage in bookPagesUserOpened)
            {
                _bookIds.Add(bookPage.BookId);
            }

            foreach (var bookRead in booksUserRead)
            {
                if (!_bookIds.Contains(bookRead.BookId))
                {
                    _bookIds.Add(bookRead.BookId);
                }
            }
        }

        private void GetAuthorRecommendations()
        {
            List<Guid> authorIds = new List<Guid>();

            var allBookAuthors = _bookAuthorService.AsQueryable().ToList();
            List<Author> authors = new List<Author>();
            List<GroupingByAuthor> groupingByAuthors = new List<GroupingByAuthor>();

            foreach (var bookId in _bookIds)
            {
                var bookAuthorId = allBookAuthors.Where(x => x.BookId == bookId).First().AuthorId;
                var author = _authorService.AsQueryable().Where(x => x.Id == bookAuthorId).FirstOrDefault();

                if (!authors.Contains(author))
                {
                    authors.Add(author);
                    groupingByAuthors.Add(
                        new GroupingByAuthor
                        {
                            Id = author.Id,
                            AuthorName = author.FirstName + " " + author.LastName,
                            NumOfBooks = 1
                        });
                }
                else
                {
                    groupingByAuthors.Where(x => x.Id == author.Id).FirstOrDefault().NumOfBooks++;
                }
            }

            var mostReadOrViewedAuthorId = groupingByAuthors.OrderByDescending(x => x.NumOfBooks).First().Id;

            var booksFromFavAuthor = _bookAuthorService
                .AsQueryable()
                .Include(x => x.Book)
                .Where(x => x.AuthorId == mostReadOrViewedAuthorId)
                .ToList();

            foreach (var book in booksFromFavAuthor)
            {
                _booksFromFavAuthorUserHasNotYetRead.Add(book.Book);
            }

            foreach (var bookUserRead in _booksUserRead)
            {
                if (_booksFromFavAuthorUserHasNotYetRead.Contains(bookUserRead.Book))
                {
                    _booksFromFavAuthorUserHasNotYetRead.Remove(bookUserRead.Book);
                }
            }
        }
    }

    class GroupingByGenre
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public int NumOfBooks { get; set; }
    }

    class GroupingByAuthor
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public int NumOfBooks { get; set; }
    }
}
