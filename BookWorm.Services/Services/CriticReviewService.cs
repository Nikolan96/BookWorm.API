using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class CriticReviewService : ICriticReviewService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CriticReviewService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<CriticReview> AsQueryable()
        {
            return _repositoryWrapper.CriticReview.AsQueryable();
        }

        public CriticReview AddCriticReview(CriticReview criticReview)
        {
            _repositoryWrapper.CriticReview.AddCriticReview(criticReview);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return criticReview;
        }

        public void RemoveCriticReview(CriticReview criticReview)
        {
            _repositoryWrapper.CriticReview.RemoveCriticReview(criticReview);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public CriticReview UpdateCriticReview(CriticReview existing, CriticReview criticReview)
        {
            _repositoryWrapper.CriticReview.UpdateCriticReview(existing, criticReview);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return criticReview;
        }
    }
}
