using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;

namespace BookWorm.Services.Services
{
    public class AuthorService : IAuthorService
    {
        //private readonly ILogger<UserService> _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AuthorService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public Author AddAuthor(Author author)
        {
            _repositoryWrapper.Author.AddAuthor(author);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return author;
        }

        public void RemoveAuthor(Author author)
        {
            _repositoryWrapper.Author.RemoveAuthor(author);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public Author UpdateAuthor(Author author)
        {
            _repositoryWrapper.Author.UpdateAuthor(author);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return author;
        }
    }
}
