using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Repositories
{
    public interface ICriticReviewRepository
    {
        void AddCriticReview(CriticReview entity);
        void RemoveCriticReview(CriticReview entity);
        void UpdateCriticReview(CriticReview entity);
    }
}