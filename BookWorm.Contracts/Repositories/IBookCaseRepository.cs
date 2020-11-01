using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Repositories
{
    public interface IBookCaseRepository
    {
        void AddBookCase(BookCase entity);
        void RemoveBookCase(BookCase entity);
        void UpdateBookCase(BookCase entity);
    }
}