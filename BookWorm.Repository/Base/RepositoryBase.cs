using BookWorm.Entities;
using BookWorm.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.Repository.Base
{
    public abstract class RepositoryBase<T> where T : EntityBase
    {
        protected DataContext DataContext { get; set; }

        protected RepositoryBase(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        //public IQueryable<T> AsQueryable()
        //{
        //    return this.DataContext.Set<T>();
        //}

        public void Add(T entity)
        {
            DataContext.Set<T>().Add(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
            // In case AsNoTracking is used
            DataContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public void Remove(T entity)
        {
            DataContext.Set<T>().Remove(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }

    }
}
