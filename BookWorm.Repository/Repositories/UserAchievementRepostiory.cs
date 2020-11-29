using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class UserAchievementRepostiory : RepositoryBase<UserAchievement>, IUserAchievementRepository
    {
        public UserAchievementRepostiory(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddUserAchievement(UserAchievement entity)
        {
            Add(entity);
        }

        public void RemoveUserAchievement(UserAchievement entity)
        {
            Remove(entity);
        }

        public void UpdateUserAchievement(UserAchievement existing, UserAchievement entity)
        {
            Update(existing, entity);
        }
    }
}
