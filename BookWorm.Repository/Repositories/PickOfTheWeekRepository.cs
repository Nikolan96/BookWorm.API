using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class PickOfTheWeekRepository : RepositoryBase<PickOfTheWeek>, IPickOfTheWeekRepository
    {
        public PickOfTheWeekRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddPickOfTheWeek(PickOfTheWeek entity)
        {
            Add(entity);
        }

        public void RemovePickOfTheWeek(PickOfTheWeek entity)
        {
            Remove(entity);
        }

        public void UpdatePickOfTheWeek(PickOfTheWeek existing, PickOfTheWeek entity)
        {
            Update(existing, entity);
        }
    }
}