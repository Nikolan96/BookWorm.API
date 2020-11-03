using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System.Linq;

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

        public IQueryable<UserReview> AsQueryable()
        {
            return _repositoryWrapper.UserReview.AsQueryable();
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

        public UserReview UpdateUserReview(UserReview existing, UserReview userReview)
        {
            _repositoryWrapper.UserReview.UpdateUserReview(existing, userReview);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return userReview;
        }
    }
}
