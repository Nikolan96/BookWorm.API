using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IBooksReadService
    {
        BooksRead AddBooksRead(BooksRead bookRead);
        void RemoveBooksRead(BooksRead bookRead);
        BooksRead UpdateBooksRead(BooksRead existing, BooksRead bookRead);
        IQueryable<BooksRead> AsQueryable();
    }
}
