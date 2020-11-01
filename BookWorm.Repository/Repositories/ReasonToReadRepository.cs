using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class ReasonToReadRepository : RepositoryBase<ReasonToRead>, IReasonToReadRepository
    {
        public ReasonToReadRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddReasonToRead(ReasonToRead entity)
        {
            Add(entity);
        }

        public void RemoveReasonToRead(ReasonToRead entity)
        {
            Remove(entity);
        }

        public void UpdateReasonToRead(ReasonToRead entity)
        {
            Update(entity);
        }
    }
}