using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class UserOpenedBookPageRepository : RepositoryBase<UserOpenedBookPage>, IUserOpenedBookPageRepository
    {
        public UserOpenedBookPageRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddUserOpenedBookPage(UserOpenedBookPage entity)
        {
            Add(entity);
        }

        public void RemoveUserOpenedBookPage(UserOpenedBookPage entity)
        {
            Remove(entity);
        }

        public void UpdateUserOpenedBookPage(UserOpenedBookPage existing, UserOpenedBookPage entity)
        {
            Update(existing, entity);
        }
    }
}
