using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IAuthorFactRepository
    {
        void AddAuthorFact(AuthorFact entity);
        void RemoveAuthorFact(AuthorFact entity);
        void UpdateAuthorFact(AuthorFact existing, AuthorFact entity);
        IQueryable<AuthorFact> AsQueryable();
    }
}