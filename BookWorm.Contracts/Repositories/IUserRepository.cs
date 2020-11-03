using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User entity);
        void RemoveUser(User entity);
        void UpdateUser(User existing, User entity);
        IQueryable<User> AsQueryable();
    }
}