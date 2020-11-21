using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IPickOfTheDayRepository
    {
        void AddPickOfTheDay(PickOfTheDay entity);
        void RemovePickOfTheDay(PickOfTheDay entity);
        void UpdatePickOfTheDay(PickOfTheDay existing, PickOfTheDay entity);
        IQueryable<PickOfTheDay> AsQueryable();
    }
}
