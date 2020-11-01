using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface ICriticReviewService
    {
        CriticReview AddCriticReview(CriticReview criticReview);
        void RemoveCriticReview(CriticReview criticReview);
        CriticReview UpdateCriticReview(CriticReview criticReview);
    }
}