using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class BookAuthorService : IBookAuthorService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BookAuthorService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<BookAuthor> AsQueryable()
        {
            return _repositoryWrapper.BookAuthor.AsQueryable();
        }

        public BookAuthor AddBookAuthor(BookAuthor bookAuthor)
        {
            _repositoryWrapper.BookAuthor.AddBookAuthor(bookAuthor);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return bookAuthor;
        }

        public void RemoveBookAuthor(BookAuthor bookAuthor)
        {
            _repositoryWrapper.BookAuthor.RemoveBookAuthor(bookAuthor);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public BookAuthor UpdateBookAuthor(BookAuthor existing, BookAuthor bookAuthor)
        {
            _repositoryWrapper.BookAuthor.UpdateBookAuthor(existing, bookAuthor);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return bookAuthor;
        }
    }
}
