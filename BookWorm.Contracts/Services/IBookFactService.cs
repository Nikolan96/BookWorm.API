using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IBookFactService
    {
        BookFact AddBookFact(BookFact bookFact);
        void RemoveBookFact(BookFact bookFact);
        BookFact UpdateBookFact(BookFact existing, BookFact bookFact);
        IQueryable<BookFact> AsQueryable();
    }
}