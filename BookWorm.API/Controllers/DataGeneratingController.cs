using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataGeneratingController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly IBookAuthorService _bookAuthorService;
        private readonly IAuthorFactService _authorFactService;
        private readonly IBookService _bookService;
        private readonly IBookFactService _bookFactService;
        private readonly ICriticReviewService _criticReviewService;
        private readonly IBooksReadService _booksReadService;
        private readonly IUserOpenedBookPageService _userOpenedBookPageService;
        private readonly IUserReviewService _userReviewService;
        private readonly IUserBookNoteService _userBookNoteService;
        private readonly IBookCaseService caseService;
        private readonly ICaseService _caseService;
        private readonly IBookCaseService _bookCaseService;
        private readonly IReasonToReadService _reasonToReadService;
        private Random _rnd = new Random();
        private List<Book> _generatedBooks = new List<Book>();
        private List<User> _generatedUsers = new List<User>();

        public DataGeneratingController(IAddressService addressService,
            IUserService userService, 
            IAuthorService authorService,
            IGenreService genreService,
            IBookAuthorService bookAuthorService,
            IAuthorFactService authorFactService,
            IBookService bookService,
            IBookFactService bookFactService,
            ICriticReviewService criticReviewService,
            IBooksReadService booksReadService,
            IUserOpenedBookPageService userOpenedBookPageService,
            IUserReviewService userReviewService,
            IUserBookNoteService userBookNoteService,
            ICaseService caseService,
            IBookCaseService bookCaseService,
            IReasonToReadService reasonToReadService
            )
        {
            _addressService = addressService;
            _userService = userService;
            _authorService = authorService;
            _genreService = genreService;
            _bookAuthorService = bookAuthorService;
            _authorFactService = authorFactService;
            _bookService = bookService;
            _bookFactService = bookFactService;
            _criticReviewService = criticReviewService;
            _booksReadService = booksReadService;
            _userOpenedBookPageService = userOpenedBookPageService;
            _userReviewService = userReviewService;
            _userBookNoteService = userBookNoteService;
            _caseService = caseService;
            _bookCaseService = bookCaseService;
            _reasonToReadService = reasonToReadService;
        }

        [HttpGet]
        [Route("GenerateData")]
        public ActionResult GenerateData()
        {
            var noGenres = !_genreService.AsQueryable().ToList().Any();
            var noTenGenres = _genreService.AsQueryable().ToList().Count < 10;

            GenerateGenresIfThereAreNoneOrLessThan10(noGenres, noTenGenres);

            // add 10 authors
            GenerateBookAndAuthorRelatedData();

            // add 5 addresses and 5 users
            GenerateAddressesAndUsers();

            // user read 5 to 10 books
            UserReadBooks(5, 10);

            // user viewed 10 - 20 book pages
            UserViewedBookPages(10, 20);

            // user reviewd 1 - 6 books
            UserReviewedBooks(1, 6);

            // user adds 1 - 5 notes for 2 - 5 books
            UserAddsNotesForBooks(2, 5, 1, 5);

            // user ima random 0 - 3 case-ova, gde svaki od njih ima 2 - 10 knjige
            UserAddsCasesWithBooks(0, 3, 2, 10);

            // generate 50 reasons to read
            GenerateReasonsToRead();

            return Ok();
        }

        private void UserReadBooks(int min, int max)
        {
            foreach (var user in _generatedUsers)
            {
                var counter = _rnd.Next(min, max);
                for (int i = 0; i < counter; i++)
                {
                    var books = _bookService
                        .AsQueryable()
                        .ToList();
                    var rndBookId = books[_rnd.Next(0, books.Count - 1)].Id;

                    var alreadyRead = _booksReadService
                        .AsQueryable()
                        .Where(x => x.UserId == user.Id && x.BookId == rndBookId)
                        .FirstOrDefault();

                    if (alreadyRead is null)
                    {
                        var newBookRead = new BooksRead
                        {
                            UserId = user.Id,
                            BookId = rndBookId
                        };

                        _booksReadService.AddBooksRead(newBookRead);
                    }
                }
            }
        }

        private void UserAddsCasesWithBooks(int caseMin, int caseMax,int bookMin, int bookMax)
        {
            foreach (var user in _generatedUsers)
            {
                var caseCounter = _rnd.Next(caseMin, caseMax);
                var bookCounter = _rnd.Next(bookMin, bookMax);

                for (int i = 0; i < caseCounter; i++)
                {

                    var newCase = new Case
                    {
                        UserId = user.Id,
                        Title = GetRandomString()
                    };

                    var insertedCase = _caseService.AddCase(newCase);

                    for (int j = 0; j < bookCounter; j++)
                    {
                        var books = _bookService
                            .AsQueryable()
                            .ToList();

                        var rndBookId = books[_rnd.Next(0, books.Count - 1)].Id;

                        var newBookCase = new BookCase
                        {
                            BookId = rndBookId,
                            CaseId = insertedCase.Id,
                        };

                        _bookCaseService.AddBookCase(newBookCase);
                    }
                }
            }
        }

        private void UserViewedBookPages(int min, int max)
        {
            foreach (var user in _generatedUsers)
            {
                var counter = _rnd.Next(min, max);
                for (int i = 0; i < counter; i++)
                {
                    var books = _bookService
                        .AsQueryable()
                        .ToList();
                    var rndBookId = books[_rnd.Next(0, books.Count - 1)].Id;

                    var alreadyViewed = _userOpenedBookPageService
                        .AsQueryable()
                        .Where(x => x.UserId == user.Id && x.BookId == rndBookId)
                        .FirstOrDefault();

                    if (alreadyViewed is null)
                    {
                        var newUserOpenedBookPage = new UserOpenedBookPage
                        {
                            UserId = user.Id,
                            BookId = rndBookId
                        };

                        _userOpenedBookPageService.AddUserOpenedBookPage(newUserOpenedBookPage);
                    }
                }
            }
        }

        private void UserAddsNotesForBooks(int minBook, int maxBook, int minNote, int MaxNote)
        {
            foreach (var user in _generatedUsers)
            {
                var bookCounter = _rnd.Next(minBook, maxBook);
                var noteCounter = _rnd.Next(minNote, MaxNote);
                for (int i = 0; i < bookCounter; i++)
                {
                    var books = _bookService
                        .AsQueryable()
                        .ToList();

                    var rndBookId = books[_rnd.Next(0, books.Count - 1)].Id;

                    for (int j = 0; j < noteCounter; j++)
                    {
                        var newUserBookNote = new UserBookNote
                        {
                            UserId = user.Id,
                            BookId = rndBookId,
                            Text = GetLoremIpsumText(),
                            Title = GetRandomString()
                        };

                        _userBookNoteService.AddUserBookNote(newUserBookNote);
                    }
                }
            }
        }

        private void UserReviewedBooks(int min, int max)
        {
            foreach (var user in _generatedUsers)
            {
                var counter = _rnd.Next(min, max);
                for (int i = 0; i < counter; i++)
                {
                    var books = _bookService
                        .AsQueryable()
                        .ToList();
                    var rndBookId = books[_rnd.Next(0, books.Count - 1)].Id;

                    var alreadyReviewed = _userReviewService
                        .AsQueryable()
                        .Where(x => x.UserId == user.Id && x.BookId == rndBookId)
                        .FirstOrDefault();

                    if (alreadyReviewed is null)
                    {
                        var newUserReview = new UserReview
                        {
                            UserId = user.Id,
                            BookId = rndBookId,
                            Text = GetLoremIpsumText(),
                            Rating = GetRandomInt()
                        };

                        _userReviewService.AddUserReview(newUserReview);
                    }
                }
            }
        }

        private void GenerateReasonsToRead()
        {
            for (int i = 0; i < 50; i++)
            {
                var newReasonToRead = new ReasonsToRead
                {
                    Text = GetRandomString()
                };

                _reasonToReadService.AddReasonToRead(newReasonToRead);
            }
        }

        private void GenerateBookAndAuthorRelatedData()
        {
            for (int i = 0; i < 10; i++)
            {
                Author author = GenerateAuthorRelatedDate();

                // generate 15 books for author
                GenerateBookRelatedData(author);
            }
        }

        private void GenerateBookRelatedData(Author author)
        {
            for (int j = 0; j < 15; j++)
            {
                var genres = _genreService.AsQueryable().ToList();

                var rndGenre = genres[_rnd.Next(0, genres.Count - 1)];

                Book book = GenerateBook(rndGenre);

                var newBookAuthor = new BookAuthor
                {
                    AuthorId = author.Id,
                    BookId = book.Id
                };

                _bookAuthorService.AddBookAuthor(newBookAuthor);
                GenerateBookFactsAndCriticReviews(book);
            }
        }

        private void GenerateBookFactsAndCriticReviews(Book book)
        {
            for (int f = 0; f < 2; f++)
            {
                var newBookFact = new BookFact
                {
                    BookId = book.Id,
                    Text = GetRandomString()
                };

                _bookFactService.AddBookFact(newBookFact);
            }

            for (int e = 0; e < 2; e++)
            {
                var newCriticReview = new CriticReview
                {
                    BookId = book.Id,
                    Text = GetRandomString(),
                    Title = GetRandomString(),
                    Rating = GetRandomDouble()
                };

                _criticReviewService.AddCriticReview(newCriticReview);
            }
        }

        private Book GenerateBook(Genre rndGenre)
        {
            var newBook = new Book
            {
                ISBN = GetRandomString(),
                PublishDate = GetRandomDateTime(),
                GenreId = rndGenre.Id,
                Title = GetRandomString()
            };

            var book = _bookService.AddBook(newBook);
            _generatedBooks.Add(book);
            return book;
        }

        private Author GenerateAuthorRelatedDate()
        {
            var newAuthor = new Author
            {
                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                ShortBio = GetRandomString(),
                BirthDate = GetRandomDateTime()
            };

            var author = _authorService.AddAuthor(newAuthor);

            // generate 5 facts about author
            for (int q = 0; q < 5; q++)
            {
                var newAuthorFact = new AuthorFact
                {
                    AuthorId = author.Id,
                    Text = GetRandomString()
                };

                _authorFactService.AddAuthorFact(newAuthorFact);
            }

            return author;
        }

        private void GenerateGenresIfThereAreNoneOrLessThan10(bool noGenres, bool noFiveGenres)
        {
            if (noGenres || noFiveGenres)
            {
                // if there are no 10 genres, generate 10
                for (int i = 0; i < 10; i++)
                {
                    var newGenre = new Genre
                    {
                        Name = GetRandomString()
                    };

                    _genreService.AddGenre(newGenre);
                }
            }
        }

        private string GetRandomGender()
        {
            List<string> genders = new List<string>
            {
                "Male",
                "Female"
            };

            return genders[_rnd.Next(0, 1)];
        }

        private void GenerateAddressesAndUsers()
        {
            for (int j = 0; j < 5; j++)
            {
                var newAddress = new Address
                {
                    Line1 = GetRandomString(),
                    City = GetRandomString(),
                    Country = GetRandomString()
                };

                var address = _addressService.AddAddress(newAddress);

                var newUser = new User
                {
                    AddressId = address.Id,
                    LastName = GetRandomString(),
                    FirstName = GetRandomString(),
                    DateOfBirth = GetRandomDateTime(),
                    Gender = GetRandomGender(),
                    Email = GetRandomEmail(),
                    Password = GetRandomString()
                };

                var user = _userService.AddUser(newUser);
                _generatedUsers.Add(user);
            }
        }

        private string GetRandomString()
        {
            int length = _rnd.Next(1, 20);

            StringBuilder str_build = new StringBuilder();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = _rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        private DateTime GetRandomDateTime()
        {
            return DateTime.Now;
        }

        private double GetRandomDouble()
        {
            return _rnd.NextDouble() * (5 - 1) + 1;
        }

        private string GetRandomName()
        {
            int length = _rnd.Next(1,20);

            StringBuilder str_build = new StringBuilder();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = _rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        private string GetRandomLastName()
        {
            int length = _rnd.Next(1, 20);

            StringBuilder str_build = new StringBuilder();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = _rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        private string GetRandomTitle()
        {
            List<string> titles = new List<string>
            {
                "Do Androids Dream of Electric Sheep?",

            };
            return "";
        }

        private string GetRandomEmail()
        {
            int length = _rnd.Next(3, 15);
            List<string> emailProviders = new List<string>
            {
                "@gmail.com",
                "@hotmail.com",
                "@live.com"
            };

            StringBuilder str_build = new StringBuilder();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = _rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString() + emailProviders[_rnd.Next(0, emailProviders.Count-1)];
        }

        private string GetLoremIpsumText()
        {
            return "Lorem Ipsum is simply dummy text of the" +
                " printing and typesetting industry. Lorem " +
                "Ipsum has been the industry's standard dummy " +
                "text ever since the 1500s, when an unknown printer" +
                " took a galley of type and scrambled it to make a " +
                "type specimen book. It has survived not only five " +
                "centuries, but also the leap into electronic typesetting," +
                " remaining essentially unchanged. It was popularised in " +
                "the 1960s with the release of Letraset sheets containing " +
                "Lorem Ipsum passages, and more recently with desktop " +
                "publishing software like Aldus PageMaker including " +
                "versions of Lorem Ipsum.";
        }

        private int GetRandomInt()
        {
            return _rnd.Next(0,5);
        }

        private string GetRandomGenre()
        {
            List<string> genres = new List<string>
            {
                "Action and adventure",
                "Alternate history",
                "Anthology",
                "Classic",
                "Crime",
                "Fairytale",
                "Mystery",
                "Poetry",
                "Romance",
                "Thriller",
                "Satire",
                "Political thriller",
                "Western",
                "Science Fiction",
                "Autobiography",
                "Biography",
                "Diary",
                "Encyclopedia",
                "Health/fitness",
                "Memoir",
                "True crime"
            };
            return genres[_rnd.Next(0, genres.Count - 1)];
        }
    }
}
