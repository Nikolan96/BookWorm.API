using BookWorm.Contracts.Repositories;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities;
using BookWorm.Repository.Repositories;

namespace BookWorm.Services.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext _dataContext;

        private IAuthorFactRepository _authorFactRepository;
        private IAuthorRepository _authorRepository;
        private IBookAuthorRepository _bookAuthorRepository;
        private IBookCaseRepository _bookCaseRepository;
        private IBookFactRepository _bookFactRepository;
        private IBookRepository _bookRepository;
        private ICaseRepository _caseRepository;
        private ICriticReviewRepository _criticReviewRepository;
        private IReasonToReadRepository _reasonToReadRepository;
        private IUserRepository _userRepository;
        private IUserReviewRepository _userReviewRepository;
        private IUserBookNoteRepository _userBookNoteRepository;

        public RepositoryWrapper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IUserBookNoteRepository UserBookNote
        {
            get
            {

                if (_userBookNoteRepository == null)
                {
                    _userBookNoteRepository = new UserBookNoteRepository(_dataContext);
                }

                return _userBookNoteRepository;
            }
        }

        public IAuthorFactRepository AuthorFact
        {
            get
            {

                if (_authorFactRepository == null)
                {
                    _authorFactRepository = new AuthorFactRepository(_dataContext);
                }

                return _authorFactRepository;
            }
        }

        public IAuthorRepository Author
        {
            get
            {

                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_dataContext);
                }

                return _authorRepository;
            }
        }

        public IBookAuthorRepository BookAuthor
        {
            get
            {

                if (_bookAuthorRepository == null)
                {
                    _bookAuthorRepository = new BookAuthorRepository(_dataContext);
                }

                return _bookAuthorRepository;
            }
        }

        public IBookCaseRepository BookCase
        {
            get
            {

                if (_bookCaseRepository == null)
                {
                    _bookCaseRepository = new BookCaseRepository(_dataContext);
                }

                return _bookCaseRepository;
            }
        }

        public IBookFactRepository BookFact
        {
            get
            {

                if (_bookFactRepository == null)
                {
                    _bookFactRepository = new BookFactRepository(_dataContext);
                }

                return _bookFactRepository;
            }
        }

        public IBookRepository Book
        {
            get
            {

                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_dataContext);
                }

                return _bookRepository;
            }
        }

        public ICaseRepository Case
        {
            get
            {

                if (_caseRepository == null)
                {
                    _caseRepository = new CaseRepository(_dataContext);
                }

                return _caseRepository;
            }
        }

        public ICriticReviewRepository CriticReview
        {
            get
            {

                if (_criticReviewRepository == null)
                {
                    _criticReviewRepository = new CriticReviewRepository(_dataContext);
                }

                return _criticReviewRepository;
            }
        }

        public IReasonToReadRepository ReasonToRead
        {
            get
            {

                if (_reasonToReadRepository == null)
                {
                    _reasonToReadRepository = new ReasonToReadRepository(_dataContext);
                }

                return _reasonToReadRepository;
            }
        }

        public IUserRepository User
        {
            get
            {

                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dataContext);
                }

                return _userRepository;
            }
        }
        public IUserReviewRepository UserReview
        {
            get
            {

                if (_userReviewRepository == null)
                {
                    _userReviewRepository = new UserReviewRepository(_dataContext);
                }

                return _userReviewRepository;
            }
        }

    }
}
