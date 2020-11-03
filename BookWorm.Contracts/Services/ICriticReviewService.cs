using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface ICriticReviewService
    {
        CriticReview AddCriticReview(CriticReview criticReview);
        void RemoveCriticReview(CriticReview criticReview);
        CriticReview UpdateCriticReview(CriticReview existing, CriticReview criticReview);
        IQueryable<CriticReview> AsQueryable();
    }
}