using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IReasonToReadRepository
    {
        void AddReasonToRead(ReasonToRead entity);
        void RemoveReasonToRead(ReasonToRead entity);
        void UpdateReasonToRead(ReasonToRead existing, ReasonToRead entity);
        IQueryable<ReasonToRead> AsQueryable();
    }
}