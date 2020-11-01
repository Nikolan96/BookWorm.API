using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class BookFactRepository : RepositoryBase<BookFact>, IBookFactRepository
    {
        public BookFactRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddBookFact(BookFact entity)
        {
            Add(entity);
        }

        public void RemoveBookFact(BookFact entity)
        {
            Remove(entity);
        }

        public void UpdateBookFact(BookFact entity)
        {
            Update(entity);
        }
    }
}