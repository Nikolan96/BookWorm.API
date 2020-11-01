using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System;
using BookWorm.Contracts.Services;
using System.Collections.Generic;
using System.Text;

namespace BookWorm.Services.Services
{
    public class UserReviewService : IUserReviewService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserReviewService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public UserReview AddUserReview(UserReview userReview)
        {
            _repositoryWrapper.UserReview.AddUserReview(userReview);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return userReview;
        }

        public void RemoveUserReview(UserReview userReview)
        {
            _repositoryWrapper.UserReview.RemoveUserReview(userReview);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public UserReview UpdateUserReview(UserReview userReview)
        {
            _repositoryWrapper.UserReview.UpdateUserReview(userReview);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return userReview;
        }
    }
}
