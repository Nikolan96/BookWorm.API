using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface IBookAuthorService
    {
        BookAuthor AddBookAuthor(BookAuthor bookAuthor);
        void RemoveBookAuthor(BookAuthor bookAuthor);
        BookAuthor UpdateBookAuthor(BookAuthor bookAuthor);
    }
}