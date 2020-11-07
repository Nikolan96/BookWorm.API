using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class UserBookNoteRepository : RepositoryBase<UserBookNote>, IUserBookNoteRepository
    {
        public UserBookNoteRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddUserBookNote(UserBookNote entity)
        {
            Add(entity);
        }

        public void RemoveUserBookNote(UserBookNote entity)
        {
            Remove(entity);
        }

        public void UpdateUserBookNote(UserBookNote existing, UserBookNote entity)
        {
            Update(existing, entity);
        }
    }
}
