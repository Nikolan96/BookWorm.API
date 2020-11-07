using BookWorm.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWorm.Contracts.Repositories
{
    public interface IAddressRepository
    {
        void AddAddress(Address entity);
        void RemoveAddress(Address entity);
        void UpdateAddress(Address existing, Address entity);
        IQueryable<Address> AsQueryable();
    }
}
