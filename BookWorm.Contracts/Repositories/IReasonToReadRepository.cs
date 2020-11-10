using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IReasonToReadRepository
    {
        void AddReasonToRead(ReasonsToRead entity);
        void RemoveReasonToRead(ReasonsToRead entity);
        void UpdateReasonToRead(ReasonsToRead existing, ReasonsToRead entity);
        IQueryable<ReasonsToRead> AsQueryable();
    }
}