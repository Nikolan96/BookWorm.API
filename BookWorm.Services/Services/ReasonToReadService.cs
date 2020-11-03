using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class ReasonToReadService : IReasonToReadService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ReasonToReadService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<ReasonToRead> AsQueryable()
        {
            return _repositoryWrapper.ReasonToRead.AsQueryable();
        }

        public ReasonToRead AddReasonToRead(ReasonToRead reasonToRead)
        {
            _repositoryWrapper.ReasonToRead.AddReasonToRead(reasonToRead);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return reasonToRead;
        }

        public void RemoveReasonToRead(ReasonToRead reasonToRead)
        {
            _repositoryWrapper.ReasonToRead.RemoveReasonToRead(reasonToRead);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public ReasonToRead UpdateReasonToRead(ReasonToRead existing, ReasonToRead reasonToRead)
        {
            _repositoryWrapper.ReasonToRead.UpdateReasonToRead(existing, reasonToRead);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return reasonToRead;
        }
    }
}
