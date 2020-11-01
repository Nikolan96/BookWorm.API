using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface IBookFactService
    {
        BookFact AddBookFact(BookFact bookFact);
        void RemoveBookFact(BookFact bookFact);
        BookFact UpdateBookFact(BookFact bookFact);
    }
}