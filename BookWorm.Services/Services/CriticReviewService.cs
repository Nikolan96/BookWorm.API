using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System;
using BookWorm.Contracts.Services;
using System.Collections.Generic;
using System.Text;

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

        public CriticReview UpdateCriticReview(CriticReview criticReview)
        {
            _repositoryWrapper.CriticReview.UpdateCriticReview(criticReview);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return criticReview;
        }
    }
}
