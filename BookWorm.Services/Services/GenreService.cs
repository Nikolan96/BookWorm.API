using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GenreService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<Genre> AsQueryable()
        {
            return _repositoryWrapper.Genre.AsQueryable();
        }

        public Genre AddGenre(Genre address)
        {
            _repositoryWrapper.Genre.AddGenre(address);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return address;
        }

        public void RemoveGenre(Genre genre)
        {
            _repositoryWrapper.Genre.RemoveGenre(genre);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public Genre UpdateGenre(Genre existing, Genre genre)
        {
            _repositoryWrapper.Genre.UpdateGenre(existing, genre);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return genre;
        }
    }
}
