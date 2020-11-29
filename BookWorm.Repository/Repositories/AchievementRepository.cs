using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class AchievementRepository : RepositoryBase<Achievement>, IAchievementRepository
    {
        public AchievementRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddAchievement(Achievement entity)
        {
            Add(entity);
        }

        public void RemoveAchievement(Achievement entity)
        {
            Remove(entity);
        }

        public void UpdateAchievement(Achievement existing, Achievement entity)
        {
            Update(existing, entity);
        }
    }
}
