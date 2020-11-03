using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IReasonToReadService
    {
        ReasonToRead AddReasonToRead(ReasonToRead reasonToRead);
        void RemoveReasonToRead(ReasonToRead reasonToRead);
        ReasonToRead UpdateReasonToRead(ReasonToRead existing, ReasonToRead reasonToRead);
        IQueryable<ReasonToRead> AsQueryable();
    }
}