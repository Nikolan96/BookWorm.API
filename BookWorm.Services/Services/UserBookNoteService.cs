using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class UserBookNoteService : IUserBookNoteService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserBookNoteService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<UserBookNote> AsQueryable()
        {
            return _repositoryWrapper.UserBookNote.AsQueryable();
        }

        public UserBookNote AddUserBookNote(UserBookNote bookNote)
        {
            _repositoryWrapper.UserBookNote.AddUserBookNote(bookNote);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return bookNote;
        }

        public void RemoveUserBookNote(UserBookNote bookNote)
        {
            _repositoryWrapper.UserBookNote.RemoveUserBookNote(bookNote);
            // _logger.WriteInfo($"Removed UserBookNote with id: {user.Id}.");
        }

        public UserBookNote UpdateUserBookNote(UserBookNote existing, UserBookNote bookNote)
        {
            _repositoryWrapper.UserBookNote.UpdateUserBookNote(existing, bookNote);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return bookNote;
        }
    }
}
