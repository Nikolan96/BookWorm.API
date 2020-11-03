using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IAuthorFactService
    {
        AuthorFact AddAuthorFact(AuthorFact authorFact);
        void RemoveAuthorFact(AuthorFact authorFact);
        AuthorFact UpdateAuthorFact(AuthorFact existing, AuthorFact authorFact);
        IQueryable<AuthorFact> AsQueryable();
    }
}