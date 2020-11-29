using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IAchievementService
    {
        Achievement AddAchievement(Achievement address);
        void RemoveAchievement(Achievement address);
        Achievement UpdateAchievement(Achievement existing, Achievement address);
        IQueryable<Achievement> AsQueryable();
    }
}
