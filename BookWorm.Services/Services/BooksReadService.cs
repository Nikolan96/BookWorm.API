using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class BooksReadService : IBooksReadService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BooksReadService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<BooksRead> AsQueryable()
        {
            return _repositoryWrapper.BooksRead.AsQueryable();
        }

        public BooksRead AddBooksRead(BooksRead bookRead)
        {
            _repositoryWrapper.BooksRead.AddBooksRead(bookRead);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return bookRead;
        }

        public void RemoveBooksRead(BooksRead bookRead)
        {
            _repositoryWrapper.BooksRead.RemoveBooksRead(bookRead);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public BooksRead UpdateBooksRead(BooksRead existing, BooksRead bookRead)
        {
            _repositoryWrapper.BooksRead.UpdateBooksRead(existing, bookRead);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return bookRead;
        }
    }
}
