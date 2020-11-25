using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class PickOfTheWeekService : IPickOfTheWeekService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PickOfTheWeekService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<PickOfTheWeek> AsQueryable()
        {
            return _repositoryWrapper.PickOfTheWeek.AsQueryable();
        }

        public PickOfTheWeek AddPickOfTheWeek(PickOfTheWeek PickOfTheWeek)
        {
            _repositoryWrapper.PickOfTheWeek.AddPickOfTheWeek(PickOfTheWeek);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return PickOfTheWeek;
        }

        public void RemovePickOfTheWeek(PickOfTheWeek PickOfTheWeek)
        {
            _repositoryWrapper.PickOfTheWeek.RemovePickOfTheWeek(PickOfTheWeek);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public PickOfTheWeek UpdatePickOfTheWeek(PickOfTheWeek existing, PickOfTheWeek PickOfTheWeek)
        {
            _repositoryWrapper.PickOfTheWeek.UpdatePickOfTheWeek(existing, PickOfTheWeek);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return PickOfTheWeek;
        }
    }
}