using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IAuthorRepository
    {
        void AddAuthor(Author entity);
        void RemoveAuthor(Author entity);
        void UpdateAuthor(Author existing, Author entity);
        IQueryable<Author> AsQueryable();
    }
}