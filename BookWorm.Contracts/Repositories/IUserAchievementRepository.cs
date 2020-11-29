using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IUserAchievementRepository
    {
        void AddUserAchievement(UserAchievement entity);
        void RemoveUserAchievement(UserAchievement entity);
        void UpdateUserAchievement(UserAchievement existing, UserAchievement entity);
        IQueryable<UserAchievement> AsQueryable();
    }
}
