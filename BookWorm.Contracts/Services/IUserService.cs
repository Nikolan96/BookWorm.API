using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IUserService
    {
        User AddUser(User user);
        void RemoveUser(User user);
        User UpdateUser(User existing, User user);
        IQueryable<User> AsQueryable();
    }
}