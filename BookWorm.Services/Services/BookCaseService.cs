using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWorm.Services.Services
{
    public class BookCaseService : IBookCaseService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BookCaseService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public BookCase AddBookCase(BookCase bookCase)
        {
            _repositoryWrapper.BookCase.AddBookCase(bookCase);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return bookCase;
        }

        public void RemoveBookCase(BookCase bookCase)
        {
            _repositoryWrapper.BookCase.RemoveBookCase(bookCase);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public BookCase UpdateBookCase(BookCase bookCase)
        {
            _repositoryWrapper.BookCase.UpdateBookCase(bookCase);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return bookCase;
        }
    }
}
