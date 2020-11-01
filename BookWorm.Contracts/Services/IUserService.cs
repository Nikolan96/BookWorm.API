using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface IUserService
    {
        User AddUser(User user);
        void RemoveUser(User user);
        User UpdateUser(User user);
    }
}