using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AchievementService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<Achievement> AsQueryable()
        {
            return _repositoryWrapper.Achievement.AsQueryable();
        }

        public Achievement AddAchievement(Achievement Achievement)
        {
            _repositoryWrapper.Achievement.AddAchievement(Achievement);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return Achievement;
        }

        public void RemoveAchievement(Achievement Achievement)
        {
            _repositoryWrapper.Achievement.RemoveAchievement(Achievement);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public Achievement UpdateAchievement(Achievement existing, Achievement Achievement)
        {
            _repositoryWrapper.Achievement.UpdateAchievement(existing, Achievement);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return Achievement;
        }
    }
}
