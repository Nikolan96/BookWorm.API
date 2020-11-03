using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BookService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<Book> AsQueryable()
        {
            return _repositoryWrapper.Book.AsQueryable();
        }

        public Book AddBook(Book book)
        {
            _repositoryWrapper.Book.AddBook(book);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return book;
        }

        public void RemoveBook(Book book)
        {
            _repositoryWrapper.Book.RemoveBook(book);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public Book UpdateBook(Book existing, Book book)
        {
            _repositoryWrapper.Book.UpdateBook(existing, book);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return book;
        }
    }
}
