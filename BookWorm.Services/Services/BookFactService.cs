using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class BookFactService : IBookFactService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BookFactService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<BookFact> AsQueryable()
        {
            return _repositoryWrapper.BookFact.AsQueryable();
        }

        public BookFact AddBookFact(BookFact bookFact)
        {
            _repositoryWrapper.BookFact.AddBookFact(bookFact);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return bookFact;
        }

        public void RemoveBookFact(BookFact bookFact)
        {
            _repositoryWrapper.BookFact.RemoveBookFact(bookFact);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public BookFact UpdateBookFact(BookFact existing, BookFact bookFact)
        {
            _repositoryWrapper.BookFact.UpdateBookFact(existing, bookFact);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return bookFact;
        }
    }
}
