using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IBooksReadRepository
    {
        void AddBooksRead(BooksRead entity);
        void RemoveBooksRead(BooksRead entity);
        void UpdateBooksRead(BooksRead existing, BooksRead entity);
        IQueryable<BooksRead> AsQueryable();
    }
}
