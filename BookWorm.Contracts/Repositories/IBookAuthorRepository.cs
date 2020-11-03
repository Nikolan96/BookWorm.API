using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IBookAuthorRepository
    {
        void AddBookAuthor(BookAuthor entity);
        void RemoveBookAuthor(BookAuthor entity);
        void UpdateBookAuthor(BookAuthor existing, BookAuthor entity);
        IQueryable<BookAuthor> AsQueryable();
    }
}