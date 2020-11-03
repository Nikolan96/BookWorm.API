using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book entity);
        void RemoveBook(Book entity);
        void UpdateBook(Book existing, Book entity);
        IQueryable<Book> AsQueryable();
    }
}