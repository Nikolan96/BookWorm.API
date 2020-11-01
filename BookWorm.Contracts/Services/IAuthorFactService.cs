using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface IAuthorFactService
    {
        AuthorFact AddAuthorFact(AuthorFact authorFact);
        void RemoveAuthorFact(AuthorFact authorFact);
        AuthorFact UpdateAuthorFact(AuthorFact authorFact);
    }
}