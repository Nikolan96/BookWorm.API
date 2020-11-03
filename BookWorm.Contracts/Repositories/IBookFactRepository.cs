using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IBookFactRepository
    {
        void AddBookFact(BookFact entity);
        void RemoveBookFact(BookFact entity);
        void UpdateBookFact(BookFact existing, BookFact entity);
        IQueryable<BookFact> AsQueryable();
    }
}