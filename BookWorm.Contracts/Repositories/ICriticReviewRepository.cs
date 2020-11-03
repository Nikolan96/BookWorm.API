using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface ICriticReviewRepository
    {
        void AddCriticReview(CriticReview entity);
        void RemoveCriticReview(CriticReview entity);
        void UpdateCriticReview(CriticReview existing, CriticReview entity);
        IQueryable<CriticReview> AsQueryable();
    }
}