using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddAuthor(Author entity)
        {
            Add(entity);
        }

        public void RemoveAuthor(Author entity)
        {
            Remove(entity);
        }

        public void UpdateAuthor(Author entity)
        {
            Update(entity);
        }
    }
}
