using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface IReasonToReadService
    {
        ReasonToRead AddReasonToRead(ReasonToRead reasonToRead);
        void RemoveReasonToRead(ReasonToRead reasonToRead);
        ReasonToRead UpdateReasonToRead(ReasonToRead reasonToRead);
    }
}