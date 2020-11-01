using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class CriticReviewRepository : RepositoryBase<CriticReview>, ICriticReviewRepository
    {
        public CriticReviewRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddCriticReview(CriticReview entity)
        {
            Add(entity);
        }

        public void RemoveCriticReview(CriticReview entity)
        {
            Remove(entity);
        }

        public void UpdateCriticReview(CriticReview entity)
        {
            Update(entity);
        }
    }
}