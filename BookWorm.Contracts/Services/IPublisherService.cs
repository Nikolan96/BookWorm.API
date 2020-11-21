using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IPublisherService
    {
        Publisher AddPublisher(Publisher publisher);
        void RemovePublisher(Publisher publisher);
        Publisher UpdatePublisher(Publisher existing, Publisher publisher);
        IQueryable<Publisher> AsQueryable();
    }
}
