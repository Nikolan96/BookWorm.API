using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IReasonToReadService
    {
        ReasonsToRead AddReasonToRead(ReasonsToRead reasonToRead);
        void RemoveReasonToRead(ReasonsToRead reasonToRead);
        ReasonsToRead UpdateReasonToRead(ReasonsToRead existing, ReasonsToRead reasonToRead);
        IQueryable<ReasonsToRead> AsQueryable();
    }
}