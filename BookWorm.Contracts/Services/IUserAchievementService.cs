using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IUserAchievementService
    {
        UserAchievement AddUserAchievement(UserAchievement userAchievement);
        void RemoveUserAchievement(UserAchievement userAchievement);
        UserAchievement UpdateUserAchievement(UserAchievement existing, UserAchievement userAchievement);
        IQueryable<UserAchievement> AsQueryable();
    }
}
