using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class CaseService : ICaseService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CaseService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<Case> AsQueryable()
        {
            return _repositoryWrapper.Case.AsQueryable();
        }

        public Case AddCase(Case @case)
        {
            _repositoryWrapper.Case.AddCase(@case);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return @case;
        }

        public void RemoveCase(Case @case)
        {
            _repositoryWrapper.Case.RemoveCase(@case);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public Case UpdateCase(Case existing, Case @case)
        {
            _repositoryWrapper.Case.UpdateCase(existing, @case);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return @case;
        }
    }
}
