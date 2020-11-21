using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IPickOfTheDayService
    {
        PickOfTheDay AddPickOfTheDay(PickOfTheDay pickOfTheDay);
        void RemovePickOfTheDay(PickOfTheDay pickOfTheDay);
        PickOfTheDay UpdatePickOfTheDay(PickOfTheDay existing, PickOfTheDay pickOfTheDay);
        IQueryable<PickOfTheDay> AsQueryable();
    }
}
