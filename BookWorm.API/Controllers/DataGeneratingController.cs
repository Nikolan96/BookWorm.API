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
        private readonly ICaseService _caseService;
        private readonly IBookCaseService _bookCaseService;
        private readonly IReasonToReadService _reasonToReadService;
        private readonly IRoleService _roleService;

        private Random _rnd = new Random();
        private List<Book> _generatedBooks = new List<Book>();
        private List<User> _generatedUsers = new List<User>();
        private List<string> _genresList = new List<string>();
        private List<string> _bookTitles = new List<string>();
        private DateTime _start = new DateTime(1965, 1, 1);
        private int _range;

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
            IReasonToReadService reasonToReadService,
            IRoleService roleService
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
            _roleService = roleService;

            PopulateGenresList(); 
            PopulateBookTitleList();
            _range = (new DateTime(2002, 1, 1) - _start).Days;
        }

        [HttpGet]
        [Route("GenerateData")]
        public ActionResult GenerateData()
        {
            GenerateRoles();

            GenerateGenres();

            // add 10 authors
            GenerateBookAndAuthorRelatedData(10);

            // add 5 addresses and 5 users
            GenerateAddressesAndUsers(5);

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
            GenerateReasonsToRead(50);

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

        private void GenerateRoles()
        {
            var adminRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = "Admin"
            };

            var userRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = "User"
            };

            _roleService.AddRole(adminRole);
            _roleService.AddRole(userRole);
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

        private void GenerateReasonsToRead(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var newReasonToRead = new ReasonsToRead
                {
                    Text = GetRandomString()
                };

                _reasonToReadService.AddReasonToRead(newReasonToRead);
            }
        }

        private void GenerateBookAndAuthorRelatedData(int count)
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
                PublishDate = GetRandomDateTime(_start, _range),
                GenreId = rndGenre.Id,
                Title = GetRandomTitle()
            };

            var book = _bookService.AddBook(newBook);
            _generatedBooks.Add(book);
            return book;
        }

        private Author GenerateAuthorRelatedDate()
        {
            var newAuthor = new Author
            {
                Gender = GetRandomGender(),
                LastName = GetRandomLastName(),
                ShortBio = GetLoremIpsumText(),
                BirthDate = GetRandomDateTime(_start, _range)
            };

            if (newAuthor.Gender == "Male")
            {
                newAuthor.FirstName = GetRandomMaleName();
            }
            else
            {
                newAuthor.FirstName = GetRandomFemaleName();
            }

            var author = _authorService.AddAuthor(newAuthor);

            // generate 5 facts about author
            for (int q = 0; q < 5; q++)
            {
                var newAuthorFact = new AuthorFact
                {
                    AuthorId = author.Id,
                    Text = GetLoremIpsumText()
                };

                _authorFactService.AddAuthorFact(newAuthorFact);
            }

            return author;
        }

        private void GenerateGenres()
        {
            var genres = new List<string>();

            while (genres.Count <= 10)
            {
                var rndIndex = _rnd.Next(0, _genresList.Count - 1);
                genres.Add(_genresList[rndIndex]);              
                _genresList.RemoveAt(rndIndex);                
            }

            foreach (var genreName in _genresList)
            {
                var newGenre = new Genre
                {
                    Name = genreName
                };

                _genreService.AddGenre(newGenre);
            }
        }

        private string GetRandomGender()
        {
            List<string> genders = new List<string>
            {
                "Male",
                "Female",
                "Male",
                "Female",
                "Male",
                "Female"
            };

            return genders[_rnd.Next(0, genders.Count - 1)];
        }

        private void GenerateAddressesAndUsers(int count)
        {
            for (int j = 0; j < count; j++)
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
                    LastName = GetRandomLastName(),
                    DateOfBirth = GetRandomDateTime(_start, _range),
                    Gender = GetRandomGender(),
                    RoleId = _roleService.AsQueryable().Where(x => x.Name == "User").FirstOrDefault().Id
                };

                if (newUser.Gender == "Male")
                {
                    newUser.FirstName = GetRandomMaleName();
                }
                else
                {
                    newUser.FirstName = GetRandomFemaleName();
                }

                newUser.Email = GenerateEmail(newUser.FirstName + newUser.LastName);
                newUser.Password = GeneratePassword(newUser.FirstName);

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

        private DateTime GetRandomDateTime(DateTime start, int range)
        {
            return start.AddDays(_rnd.Next(range));
        }

        private double GetRandomDouble()
        {
            return _rnd.NextDouble() * (5 - 1) + 1;
        }

        private string GetRandomMaleName()
        {
            List<string> names = new List<string>
            {
                "James","John", "Robert","Michael",
                "William","David", "Thomas", "Charles",
                "Anthony","Mark","Kevin", "Brian",
                "Jason", "Jacob","Gary", "Raymond",
                "Patrick", "Jack","Tyler","Suamuel",
                "Scott", "Larry","Stephen","Frank",
                "George","Henry","Nathan"
            };

            return names[_rnd.Next(0, names.Count - 1)];
        }

        private string GetRandomFemaleName()
        {
            List<string> names = new List<string>
            {
                "Mary","Patricia", "Jennifer","Linda",
                "Barbara","Karen", "Sarah", "Suzan",
                "Dorothy","Ashley","Jessica", "Elizabeth",
                "Kimberly", "Emily","Donna", "Michelle",
                "Patrick", "Kathleen","Helen","Angela",
                "Carol", "Amanda","Melissa","Deborah",
                "Samantha","Emma","Anne"
            };

            return names[_rnd.Next(0, names.Count - 1)];
        }

        private string GetRandomLastName()
        {
            List<string> lastNames = new List<string>
            {
                "Smith","Johnson", "Williams","Brown",
                "Jones","Garcia", "Miller", "Davis",
                "Rodriguez","Martinez","Hernandez", "Lopez",
                "Wilson", "Anderson","Thomas", "Moore",
                "Lee", "Perez","Thompson","White",
                "Harris", "Clark","Sanchez","Lewis",
                "Green","Young","Walker"
            };

            return lastNames[_rnd.Next(0, lastNames.Count - 1)];
        }

        private string GetRandomTitle()
        {
            var index = _rnd.Next(0, _bookTitles.Count - 1);
            var title = _bookTitles[index];
            _bookTitles.RemoveAt(index);
            return title;
        }

        private string GetLoremIpsumText()
        {
            var fact1 = "Lorem Ipsum is simply dummy text of the" +
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

            var fact2 = "Lorem Ipsum is simply dummy text of the" +
                " printing and typesetting industry. Lorem " +
                "Ipsum has been the industry's standard dummy ";

            var fact3 = "type specimen book. It has survived not only five " +
                "centuries, but also the leap into electronic typesetting," +
                " remaining essentially unchanged. It was popularised in ";

            var fact4 = "Lorem Ipsum passages, and more recently with desktop " +
                "publishing software like Aldus PageMaker including " +
                "versions of Lorem Ipsum.";

            var fact5 = "Ipsum has been the industry's standard dummy " +
                "text ever since the 1500s, when an unknown printer" +
                " took a galley of type and scrambled it to make a " +
                "type specimen book. It has survived not only five " +
                "centuries, but also the leap into electronic typesetting," +
                " remaining essentially unchanged. It was popularised in " +
                "the 1960s with the release of Letraset sheets containing ";

            var facts = new List<string>
            {
                fact1, fact2, fact3, fact4, fact5
            };


            return facts[_rnd.Next(0, facts.Count - 1)];
        }

        private int GetRandomInt()
        {
            return _rnd.Next(0,5);
        }

        private string GenerateEmail(string name)
        {
            List<string> emailProviders = new List<string>
            {
                "@gmail.com",
                "@hotmail.com",
                "@live.com"
            };

            return name + emailProviders[_rnd.Next(0, emailProviders.Count - 1)];
        }

        private string GeneratePassword(string name)
        {
            return "123" + name + "456!";
        }

        private void PopulateGenresList()
        {
              _genresList.Add("Alternate history");
              _genresList.Add("Anthology");
              _genresList.Add("Classic");
              _genresList.Add("Crime");
              _genresList.Add("Fairytale");
              _genresList.Add("Mystery");
              _genresList.Add("Poetry");
              _genresList.Add("Romance");
              _genresList.Add("Thriller");
              _genresList.Add("Satire");
              _genresList.Add("Political thriller");
              _genresList.Add("Western");
              _genresList.Add("Science Fiction");
              _genresList.Add("Autobiography");
              _genresList.Add("Biography");
              _genresList.Add("Diary");
              _genresList.Add("Encyclopedia");
              _genresList.Add("Health/fitness");
              _genresList.Add("Memoir");
              _genresList.Add("True crime");
              _genresList.Add("Action and adventure");
        }

        private void PopulateBookTitleList()
        {
            _bookTitles.Add("Do Androids Dream of Electric Sheep?");
            _bookTitles.Add("Absalom, Absalom!");
            _bookTitles.Add("A time to kill");
            _bookTitles.Add("The house of Mirth");
            _bookTitles.Add("East of Eden");
            _bookTitles.Add("The sun also rises");
            _bookTitles.Add("Vile bodies");
            _bookTitles.Add("A scanner darkly");
            _bookTitles.Add("Moab is my washpot");
            _bookTitles.Add("Number the stars");
            _bookTitles.Add("Noli me tangere");
            _bookTitles.Add("Brave new world");
            _bookTitles.Add("Rosemary and Rue");
            _bookTitles.Add("Pale fire");
            _bookTitles.Add("Remembrance of things past");
            _bookTitles.Add("The fault in our stars");
            _bookTitles.Add("Cold comfort");
            _bookTitles.Add("Behold, here's poison");
            _bookTitles.Add("Band of brothers");
            _bookTitles.Add("Mortal engines");
            _bookTitles.Add("The dark tower");
            _bookTitles.Add("The sound and the fury");
            _bookTitles.Add("No wind of blame");
            _bookTitles.Add("I know why the caged bird sings");
            _bookTitles.Add("Alone on a wide, wide sea");
            _bookTitles.Add("Dance, Dance, Dance");
            _bookTitles.Add("Gone with the wind");
            _bookTitles.Add("As I lay dying");
            _bookTitles.Add("A many-splendoured thing");
            _bookTitles.Add("Things fall apart");
            _bookTitles.Add("Far from madding crowd");
            _bookTitles.Add("Tender is the night");
            _bookTitles.Add("The grapes of wrath");
            _bookTitles.Add("A passage to India");
            _bookTitles.Add("Bury my heart at wounded knee");
            _bookTitles.Add("A farewell to arms");
            _bookTitles.Add("His dark materials");
            _bookTitles.Add("No country for old men");
            _bookTitles.Add("Nectar in a sieve");
            _bookTitles.Add("A thousand splendid suns");
            _bookTitles.Add("Of mice and men");
            _bookTitles.Add("This side of paradise");
            _bookTitles.Add("Dying of the light");
            _bookTitles.Add("The line of beauty");
            _bookTitles.Add("A confederacy of dunces");
            _bookTitles.Add("The curious incident of the dog in the night");
            _bookTitles.Add("The waste land");
            _bookTitles.Add("Vanity fair");
            _bookTitles.Add("Of human bodage");
            _bookTitles.Add("The long dark tea - time of the soul");
            _bookTitles.Add("The pale king");
            _bookTitles.Add("Recalled to life");
            _bookTitles.Add("The soldier's art");
            _bookTitles.Add("Surprised");
            _bookTitles.Add("Stranger in strange land");
            _bookTitles.Add("Taming a sea horse");
            _bookTitles.Add("The wives of bath");
            _bookTitles.Add("The wind's twelve quarters");
            _bookTitles.Add("Wildfire");
            _bookTitles.Add("The world, the flesh and the devil");
            _bookTitles.Add("The king in yellow");
            _bookTitles.Add("The yellow meads");
            _bookTitles.Add("The Tormentor");
            _bookTitles.Add("The torment of others");
            _bookTitles.Add("Tiger!, Tiger!");
            _bookTitles.Add("To a God unknown");
            _bookTitles.Add("The three bears");
            _bookTitles.Add("The way of all flesh");
            _bookTitles.Add("Some buried Caesar");
            _bookTitles.Add("Specimen days");
            _bookTitles.Add("Such, such were the joys");
            _bookTitles.Add("A summer bird cage");
            _bookTitles.Add("A swiftly Tilting planet");
            _bookTitles.Add("That good night");
            _bookTitles.Add("Thrones, dominations");
            _bookTitles.Add("To sail beyond the sunset");
            _bookTitles.Add("To say nothing of the dog");
            _bookTitles.Add("Tira Lira");
            _bookTitles.Add("Time of darkness");
            _bookTitles.Add("A time of gifts");
            _bookTitles.Add("The milestone");
            _bookTitles.Add("Lillies of the field");
            _bookTitles.Add("Let us know apradise");
            _bookTitles.Add("O, Jerusalem!");
            _bookTitles.Add("It's a battlefield");
            _bookTitles.Add("Jacob have I loved");
            _bookTitles.Add("An instant in the wind");
            _bookTitles.Add("In dubious battle");
            _bookTitles.Add("In death ground");
            _bookTitles.Add("How sleep the brave");
            _bookTitles.Add("Great works of time");
            _bookTitles.Add("The green bay tree");
            _bookTitles.Add("Have his carcass");
            _bookTitles.Add("The golden bowl");
            _bookTitles.Add("A handful of dust");
            _bookTitles.Add("The heart is a lonely hunter");
            _bookTitles.Add("A far distant oasis");
            _bookTitles.Add("A fanatic heart");
            _bookTitles.Add("Endless night");
            _bookTitles.Add("Eyeless in Gaza");
            _bookTitles.Add("Fame in the spur");
            _bookTitles.Add("For a breath I Tarry");
            _bookTitles.Add("To glory and the dream");
            _bookTitles.Add("Ego dominus tuus");
            _bookTitles.Add("The doors of perception");
            _bookTitles.Add("A darkling path");
            _bookTitles.Add("Death be not proud");
            _bookTitles.Add("Cover her face");
            _bookTitles.Add("Clouds of witness");
            _bookTitles.Add("The children of men");
            _bookTitles.Add("War And Peace");
            _bookTitles.Add("In Five Years");
            _bookTitles.Add("A Court of Thorns and Roses");
            _bookTitles.Add("The Girl You Left Behind");
            _bookTitles.Add("The Great Gatsby");
            _bookTitles.Add("Call me by Your Name");
            _bookTitles.Add("The Girl in the Spider's Web");
            _bookTitles.Add("The Whistler");
            _bookTitles.Add("City of Bones");
            _bookTitles.Add("Shadows of Self");
            _bookTitles.Add("The Bazaar of Bad Dreams");
            _bookTitles.Add("Brave New World");
            _bookTitles.Add("Let us know apradise");
            _bookTitles.Add("She felt like feeling nothing");
            _bookTitles.Add("Sea of Strangers");
            _bookTitles.Add("Age of Myth");
            _bookTitles.Add("The Strange Case of Dr. Jekyll and Mr. Hyde: And Other Tales of Terror");
            _bookTitles.Add("The Power and the Glory");
            _bookTitles.Add("The Gothic");
            _bookTitles.Add("The Alchemist");
            _bookTitles.Add("How to Build a Girl");
            _bookTitles.Add("Crazy Rich Asians");
            _bookTitles.Add("1984");
            _bookTitles.Add("Beneath a Scarlet Sky");
            _bookTitles.Add("The Martian");
            _bookTitles.Add("The Road");
            _bookTitles.Add("Lolita");
            _bookTitles.Add("The Mystery in Venice");
            _bookTitles.Add("Roll of the Dice");
            _bookTitles.Add("The Moonstone");
            _bookTitles.Add("Missing Person");
            _bookTitles.Add("Like Stars in Heaven");
            _bookTitles.Add("Fire and Steel	");
            _bookTitles.Add("Emma");
            _bookTitles.Add("The Alteration");
            _bookTitles.Add("Slay Ride");
            _bookTitles.Add("The Fever Code	");
            _bookTitles.Add("The President Is Missing");
            _bookTitles.Add("The Bridge to Lucy Dunne");
            _bookTitles.Add("The Battles of Tolkien");
            _bookTitles.Add("Wide Sargasso Sea");
        }
    }
}
