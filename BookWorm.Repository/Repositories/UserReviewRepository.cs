using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class UserReviewRepository : RepositoryBase<UserReview>, IUserReviewRepository
    {
        public UserReviewRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddUserReview(UserReview entity)
        {
            Add(entity);
        }

        public void RemoveUserReview(UserReview entity)
        {
            Remove(entity);
        }

        public void UpdateUserReview(UserReview entity)
        {
            Update(entity);
        }
    }
}