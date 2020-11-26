using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IPickOfTheWeekRepository
    {
        void AddPickOfTheWeek(PickOfTheWeek entity);
        void RemovePickOfTheWeek(PickOfTheWeek entity);
        void UpdatePickOfTheWeek(PickOfTheWeek existing, PickOfTheWeek entity);
        IQueryable<PickOfTheWeek> AsQueryable();
    }
}
