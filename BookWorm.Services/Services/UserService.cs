using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<User> AsQueryable()
        {
            return _repositoryWrapper.User.AsQueryable();
        }

        public User AddUser(User user)
        {
            _repositoryWrapper.User.AddUser(user);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return user;
        }

        public void RemoveUser(User user)
        {
            _repositoryWrapper.User.RemoveUser(user);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public User UpdateUser(User existing, User user)
        {
            _repositoryWrapper.User.UpdateUser(existing, user);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return user;
        }
    }
}
