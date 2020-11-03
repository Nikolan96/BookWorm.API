using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IUserReviewService
    {
        UserReview AddUserReview(UserReview userReview);
        void RemoveUserReview(UserReview userReview);
        UserReview UpdateUserReview(UserReview existing, UserReview userReview);
        IQueryable<UserReview> AsQueryable();
    }
}