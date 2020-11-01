using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class AuthorFactRepository : RepositoryBase<AuthorFact>, IAuthorFactRepository
    {
        public AuthorFactRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddAuthorFact(AuthorFact entity)
        {
            Add(entity);
        }

        public void RemoveAuthorFact(AuthorFact entity)
        {
            Remove(entity);
        }

        public void UpdateAuthorFact(AuthorFact entity)
        {
            Update(entity);
        }
    }
}
