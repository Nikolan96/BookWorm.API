using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PublisherService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<Publisher> AsQueryable()
        {
            return _repositoryWrapper.Publisher.AsQueryable();
        }

        public Publisher AddPublisher(Publisher publisher)
        {
            _repositoryWrapper.Publisher.AddPublisher(publisher);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return publisher;
        }

        public void RemovePublisher(Publisher publisher)
        {
            _repositoryWrapper.Publisher.RemovePublisher(publisher);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public Publisher UpdatePublisher(Publisher existing, Publisher publisher)
        {
            _repositoryWrapper.Publisher.UpdatePublisher(existing, publisher);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return publisher;
        }
    }
}
