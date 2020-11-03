using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class BookAuthorRepository : RepositoryBase<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddBookAuthor(BookAuthor entity)
        {
            Add(entity);
        }

        public void RemoveBookAuthor(BookAuthor entity)
        {
            Remove(entity);
        }

        public void UpdateBookAuthor(BookAuthor existing, BookAuthor entity)
        {
            Update(existing, entity);
        }
    }
}