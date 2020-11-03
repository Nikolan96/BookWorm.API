using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IUserReviewRepository
    {
        void AddUserReview(UserReview entity);
        void RemoveUserReview(UserReview entity);
        void UpdateUserReview(UserReview existing, UserReview entity);
        IQueryable<UserReview> AsQueryable();
    }
}