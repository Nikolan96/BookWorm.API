using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Repositories
{
    public interface IUserReviewRepository
    {
        void AddUserReview(UserReview entity);
        void RemoveUserReview(UserReview entity);
        void UpdateUserReview(UserReview entity);
    }
}