using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IPublisherRepository
    {
        void AddPublisher(Publisher entity);
        void RemovePublisher(Publisher entity);
        void UpdatePublisher(Publisher existing, Publisher entity);
        IQueryable<Publisher> AsQueryable();
    }
}
