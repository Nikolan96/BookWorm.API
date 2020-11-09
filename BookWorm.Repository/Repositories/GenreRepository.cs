using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddGenre(Genre entity)
        {
            Add(entity);
        }

        public void RemoveGenre(Genre entity)
        {
            Remove(entity);
        }

        public void UpdateGenre(Genre existing, Genre entity)
        {
            Update(existing, entity);
        }
    }
}
