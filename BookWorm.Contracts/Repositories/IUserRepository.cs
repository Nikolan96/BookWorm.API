using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User entity);
        void RemoveUser(User entity);
        void UpdateUser(User entity);
    }
}