using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface IBookCaseService
    {
        BookCase AddBookCase(BookCase bookCase);
        void RemoveBookCase(BookCase bookCase);
        BookCase UpdateBookCase(BookCase bookCase);
    }
}