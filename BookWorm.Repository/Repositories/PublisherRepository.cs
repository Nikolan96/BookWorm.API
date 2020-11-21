using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {
        public PublisherRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddPublisher(Publisher entity)
        {
            Add(entity);
        }

        public void RemovePublisher(Publisher entity)
        {
            Remove(entity);
        }

        public void UpdatePublisher(Publisher existing, Publisher entity)
        {
            Update(existing, entity);
        }
    }
}
