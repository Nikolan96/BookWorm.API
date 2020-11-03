using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IBookService
    {
        Book AddBook(Book book);
        void RemoveBook(Book book);
        Book UpdateBook(Book existing, Book book);
        IQueryable<Book> AsQueryable();
    }
}