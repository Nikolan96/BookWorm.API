using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class BooksReadRepository : RepositoryBase<BooksRead>, IBooksReadRepository
    {
        public BooksReadRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddBooksRead(BooksRead entity)
        {
            Add(entity);
        }

        public void RemoveBooksRead(BooksRead entity)
        {
            Remove(entity);
        }

        public void UpdateBooksRead(BooksRead existing, BooksRead entity)
        {
            Update(existing, entity);
        }
    }
}
