using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IBookCaseService
    {
        BookCase AddBookCase(BookCase bookCase);
        void RemoveBookCase(BookCase bookCase);
        BookCase UpdateBookCase(BookCase existing, BookCase bookCase);
        IQueryable<BookCase> AsQueryable();
    }
}