using BookWorm.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWorm.Contracts.Services
{
    public interface IUserCurrentlyReadingService
    {
            UserCurrentlyReading AddUserCurrentlyReading(UserCurrentlyReading UserCurrentlyReading);
            void RemoveUserCurrentlyReading(UserCurrentlyReading UserCurrentlyReading);
            UserCurrentlyReading UpdateUserCurrentlyReading(UserCurrentlyReading existing, UserCurrentlyReading UserCurrentlyReading);
            IQueryable<UserCurrentlyReading> AsQueryable();
    }
}
