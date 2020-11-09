using BookWorm.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWorm.Contracts.Repositories
{
    public interface IGenreRepository
    {
        void AddGenre(Genre entity);
        void RemoveGenre(Genre entity);
        void UpdateGenre(Genre existing, Genre entity);
        IQueryable<Genre> AsQueryable();
    }
}
