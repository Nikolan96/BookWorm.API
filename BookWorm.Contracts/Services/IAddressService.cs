using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IAddressService
    {
        Address AddAddress(Address address);
        void RemoveAddress(Address address);
        Address UpdateAddress(Address existing, Address address);
        IQueryable<Address> AsQueryable();
    }
}
