using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface IAuthorService
    {
        Author AddAuthor(Author author);
        void RemoveAuthor(Author author);
        Author UpdateAuthor(Author author);
    }
}