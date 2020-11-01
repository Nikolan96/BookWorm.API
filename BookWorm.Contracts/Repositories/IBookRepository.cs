using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book entity);
        void RemoveBook(Book entity);
        void UpdateBook(Book entity);
    }
}