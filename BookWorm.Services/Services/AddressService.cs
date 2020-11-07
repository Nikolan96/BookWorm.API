using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AddressService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<Address> AsQueryable()
        {
            return _repositoryWrapper.Address.AsQueryable();
        }

        public Address AddAddress(Address address)
        {
            _repositoryWrapper.Address.AddAddress(address);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return address;
        }

        public void RemoveAddress(Address address)
        {
            _repositoryWrapper.Address.RemoveAddress(address);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public Address UpdateAddress(Address existing, Address address)
        {
            _repositoryWrapper.Address.UpdateAddress(existing, address);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return address;
        }
    }
}
