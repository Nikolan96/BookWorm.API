using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class UserCurrentlyReadingRepository : RepositoryBase<UserCurrentlyReading>, IUserCurrentlyReadingRepository
    {
        public UserCurrentlyReadingRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddUserCurrentlyReading(UserCurrentlyReading entity)
        {
            Add(entity);
        }

        public void RemoveUserCurrentlyReading(UserCurrentlyReading entity)
        {
            Remove(entity);
        }

        public void UpdateUserCurrentlyReading(UserCurrentlyReading existing, UserCurrentlyReading entity)
        {
            Update(existing, entity);
        }
    }
}
