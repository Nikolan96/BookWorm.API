using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddBook(Book entity)
        {
            Add(entity);
        }

        public void RemoveBook(Book entity)
        {
            Remove(entity);
        }

        public void UpdateBook(Book existing, Book entity)
        {
            Update(existing, entity);
        }
    }
}
