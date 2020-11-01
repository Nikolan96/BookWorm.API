using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface IBookService
    {
        Book AddBook(Book book);
        void RemoveBook(Book book);
        Book UpdateBook(Book book);
    }
}