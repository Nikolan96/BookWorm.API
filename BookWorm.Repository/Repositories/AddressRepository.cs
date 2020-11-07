using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddAddress(Address entity)
        {
            Add(entity);
        }

        public void RemoveAddress(Address entity)
        {
            Remove(entity);
        }

        public void UpdateAddress(Address existing, Address entity)
        {
            Update(existing, entity);
        }
    }
}
