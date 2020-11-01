using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;

namespace BookWorm.Services.Services
{
    public class AuthorFactService : IAuthorFactService
    {
        //private readonly ILogger<UserService> _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AuthorFactService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public AuthorFact AddAuthorFact(AuthorFact authorFact)
        {
            _repositoryWrapper.AuthorFact.AddAuthorFact(authorFact);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return authorFact;
        }

        public void RemoveAuthorFact(AuthorFact authorFact)
        {
            _repositoryWrapper.AuthorFact.RemoveAuthorFact(authorFact);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public AuthorFact UpdateAuthorFact(AuthorFact authorFact)
        {
            _repositoryWrapper.AuthorFact.UpdateAuthorFact(authorFact);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return authorFact;
        }
    }
}
