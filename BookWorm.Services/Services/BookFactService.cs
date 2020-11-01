using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

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

        public BookFact UpdateBookFact(BookFact bookFact)
        {
            _repositoryWrapper.BookFact.UpdateBookFact(bookFact);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return bookFact;
        }
    }
}
