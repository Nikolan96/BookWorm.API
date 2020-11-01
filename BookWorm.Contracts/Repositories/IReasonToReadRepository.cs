using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Repositories
{
    public interface IReasonToReadRepository
    {
        void AddReasonToRead(ReasonToRead entity);
        void RemoveReasonToRead(ReasonToRead entity);
        void UpdateReasonToRead(ReasonToRead entity);
    }
}