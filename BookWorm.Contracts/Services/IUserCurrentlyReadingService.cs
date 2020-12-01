using BookWorm.Entities.Entities;
using System.Linq;

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
