using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

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

        public Book UpdateBook(Book book)
        {
            _repositoryWrapper.Book.UpdateBook(book);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return book;
        }
    }
}
