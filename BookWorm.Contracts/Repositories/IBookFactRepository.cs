using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Repositories
{
    public interface IBookFactRepository
    {
        void AddBookFact(BookFact entity);
        void RemoveBookFact(BookFact entity);
        void UpdateBookFact(BookFact entity);
    }
}