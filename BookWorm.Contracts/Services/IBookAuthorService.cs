using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IBookAuthorService
    {
        BookAuthor AddBookAuthor(BookAuthor bookAuthor);
        void RemoveBookAuthor(BookAuthor bookAuthor);
        BookAuthor UpdateBookAuthor(BookAuthor existing, BookAuthor bookAuthor);
        IQueryable<BookAuthor> AsQueryable();
    }
}