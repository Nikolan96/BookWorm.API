using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IBookCaseRepository
    {
        void AddBookCase(BookCase entity);
        void RemoveBookCase(BookCase entity);
        void UpdateBookCase(BookCase existing, BookCase entity);
        IQueryable<BookCase> AsQueryable();
    }
}