using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface IUserReviewService
    {
        UserReview AddUserReview(UserReview userReview);
        void RemoveUserReview(UserReview userReview);
        UserReview UpdateUserReview(UserReview userReview);
    }
}