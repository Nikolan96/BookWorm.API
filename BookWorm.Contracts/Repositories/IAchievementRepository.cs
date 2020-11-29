using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IAchievementRepository
    {
        void AddAchievement(Achievement entity);
        void RemoveAchievement(Achievement entity);
        void UpdateAchievement(Achievement existing, Achievement entity);
        IQueryable<Achievement> AsQueryable();
    }
}
