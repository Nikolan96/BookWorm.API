using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IUserBookNoteService
    {
        UserBookNote AddUserBookNote(UserBookNote bookNote);
        void RemoveUserBookNote(UserBookNote bookNote);
        UserBookNote UpdateUserBookNote(UserBookNote existing, UserBookNote bookNote);
        IQueryable<UserBookNote> AsQueryable();
    }
}
