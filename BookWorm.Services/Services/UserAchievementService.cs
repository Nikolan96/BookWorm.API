using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class UserAchievementService : IUserAchievementService
    {
        //private readonly ILogger<UserService> _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserAchievementService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<UserAchievement> AsQueryable()
        {
            return _repositoryWrapper.UserAchievement.AsQueryable();
        }

        public UserAchievement AddUserAchievement(UserAchievement UserAchievement)
        {
            _repositoryWrapper.UserAchievement.AddUserAchievement(UserAchievement);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return UserAchievement;
        }

        public void RemoveUserAchievement(UserAchievement UserAchievement)
        {
            _repositoryWrapper.UserAchievement.RemoveUserAchievement(UserAchievement);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public UserAchievement UpdateUserAchievement(UserAchievement existing, UserAchievement UserAchievement)
        {
            _repositoryWrapper.UserAchievement.UpdateUserAchievement(existing, UserAchievement);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return UserAchievement;
        }
    }
}
