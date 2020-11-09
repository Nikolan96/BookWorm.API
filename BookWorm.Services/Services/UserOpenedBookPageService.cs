using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class UserOpenedBookPageService : IUserOpenedBookPageService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserOpenedBookPageService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<UserOpenedBookPage> AsQueryable()
        {
            return _repositoryWrapper.UserOpenedBookPage.AsQueryable();
        }

        public UserOpenedBookPage AddUserOpenedBookPage(UserOpenedBookPage address)
        {
            _repositoryWrapper.UserOpenedBookPage.AddUserOpenedBookPage(address);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return address;
        }

        public void RemoveUserOpenedBookPage(UserOpenedBookPage address)
        {
            _repositoryWrapper.UserOpenedBookPage.RemoveUserOpenedBookPage(address);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public UserOpenedBookPage UpdateUserOpenedBookPage(UserOpenedBookPage existing, UserOpenedBookPage userOpenedBookPage)
        {
            _repositoryWrapper.UserOpenedBookPage.UpdateUserOpenedBookPage(existing, userOpenedBookPage);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return userOpenedBookPage;
        }
    }
}
