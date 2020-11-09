using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class ReasonToReadRepository : RepositoryBase<ReasonsToRead>, IReasonToReadRepository
    {
        public ReasonToReadRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddReasonToRead(ReasonsToRead entity)
        {
            Add(entity);
        }

        public void RemoveReasonToRead(ReasonsToRead entity)
        {
            Remove(entity);
        }

        public void UpdateReasonToRead(ReasonsToRead existing, ReasonsToRead entity)
        {
            Update(existing, entity);
        }
    }
}