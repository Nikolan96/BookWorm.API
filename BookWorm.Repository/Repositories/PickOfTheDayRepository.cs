using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class PickOfTheDayRepository : RepositoryBase<PickOfTheDay>, IPickOfTheDayRepository
    {
        public PickOfTheDayRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddPickOfTheDay(PickOfTheDay entity)
        {
            Add(entity);
        }

        public void RemovePickOfTheDay(PickOfTheDay entity)
        {
            Remove(entity);
        }

        public void UpdatePickOfTheDay(PickOfTheDay existing, PickOfTheDay entity)
        {
            Update(existing, entity);
        }
    }
}
