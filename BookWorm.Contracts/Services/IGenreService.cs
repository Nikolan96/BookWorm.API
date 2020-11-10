using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IGenreService
    {
        Genre AddGenre(Genre genre);
        void RemoveGenre(Genre genre);
        Genre UpdateGenre(Genre existing, Genre genre);
        IQueryable<Genre> AsQueryable();
    }
}
