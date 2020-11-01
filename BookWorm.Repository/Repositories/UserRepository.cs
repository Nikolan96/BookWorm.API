using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddUser(User entity)
        {
            Add(entity);
        }

        public void RemoveUser(User entity)
        {
            Remove(entity);
        }

        public void UpdateUser(User entity)
        {
            Update(entity);
        }
    }
}