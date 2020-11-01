using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Repositories
{
    public interface IBookAuthorRepository
    {
        void AddBookAuthor(BookAuthor entity);
        void RemoveBookAuthor(BookAuthor entity);
        void UpdateBookAuthor(BookAuthor entity);
    }
}