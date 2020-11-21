using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class PickOfTheDayService : IPickOfTheDayService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PickOfTheDayService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<PickOfTheDay> AsQueryable()
        {
            return _repositoryWrapper.PickOfTheDay.AsQueryable();
        }

        public PickOfTheDay AddPickOfTheDay(PickOfTheDay address)
        {
            _repositoryWrapper.PickOfTheDay.AddPickOfTheDay(address);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return address;
        }

        public void RemovePickOfTheDay(PickOfTheDay pickOfTheDay)
        {
            _repositoryWrapper.PickOfTheDay.RemovePickOfTheDay(pickOfTheDay);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public PickOfTheDay UpdatePickOfTheDay(PickOfTheDay existing, PickOfTheDay pickOfTheDay)
        {
            _repositoryWrapper.PickOfTheDay.UpdatePickOfTheDay(existing, pickOfTheDay);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return pickOfTheDay;
        }
    }
}
