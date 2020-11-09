using BookWorm.Contracts.Repositories;

namespace BookWorm.Contracts.Wrapper
{
    public interface IRepositoryWrapper
    {
        IAuthorFactRepository AuthorFact { get; }
        IAuthorRepository Author { get; }
        IBookAuthorRepository BookAuthor { get; }
        IBookCaseRepository BookCase { get; }
        IBookFactRepository BookFact { get; }
        IBookRepository Book { get; }
        ICaseRepository Case { get; }
        ICriticReviewRepository CriticReview { get; }
        IReasonToReadRepository ReasonToRead{ get; }
        IUserRepository User { get; }
        IUserReviewRepository UserReview{ get; }
        IUserBookNoteRepository UserBookNote { get; }
        IAddressRepository Address { get; }
        IGenreRepository Genre { get; }
        IUserOpenedBookPageRepository UserOpenedBookPage { get; }
        IBooksReadRepository BooksRead { get; }
    }
}