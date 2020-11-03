using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class BookCaseRepository : RepositoryBase<BookCase>, IBookCaseRepository
    {
        public BookCaseRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddBookCase(BookCase entity)
        {
            Add(entity);
        }

        public void RemoveBookCase(BookCase entity)
        {
            Remove(entity);
        }

        public void UpdateBookCase(BookCase existing, BookCase entity)
        {
            Update(existing, entity);
        }
    }
}