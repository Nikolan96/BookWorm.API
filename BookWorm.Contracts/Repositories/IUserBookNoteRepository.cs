using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IUserBookNoteRepository
    {
        void AddUserBookNote(UserBookNote entity);
        void RemoveUserBookNote(UserBookNote entity);
        void UpdateUserBookNote(UserBookNote existing, UserBookNote entity);
        IQueryable<UserBookNote> AsQueryable();
    }
}
