using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IAuthorService
    {
        Author AddAuthor(Author author);
        void RemoveAuthor(Author author);
        Author UpdateAuthor(Author existing, Author author);
        IQueryable<Author> AsQueryable();
    }
}