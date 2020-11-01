using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Repositories
{
    public interface IAuthorFactRepository
    {
        void AddAuthorFact(AuthorFact entity);
        void RemoveAuthorFact(AuthorFact entity);
        void UpdateAuthorFact(AuthorFact entity);
    }
}