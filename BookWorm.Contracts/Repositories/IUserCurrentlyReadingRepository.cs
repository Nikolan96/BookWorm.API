using BookWorm.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWorm.Contracts.Repositories
{
    public interface IUserCurrentlyReadingRepository
    {
        void AddUserCurrentlyReading(UserCurrentlyReading entity);
        void RemoveUserCurrentlyReading(UserCurrentlyReading entity);
        void UpdateUserCurrentlyReading(UserCurrentlyReading existing, UserCurrentlyReading entity);
        IQueryable<UserCurrentlyReading> AsQueryable();
    }
}
