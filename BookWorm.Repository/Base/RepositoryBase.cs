using BookWorm.Entities;
using BookWorm.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookWorm.Repository.Base
{
    public abstract class RepositoryBase<T> where T : EntityBase
    {
        protected DataContext DataContext { get; set; }

        protected RepositoryBase(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IQueryable<T> AsQueryable()
        {
            return DataContext.Set<T>();
        }

        public void Add(T entity)
        {
            DataContext.Set<T>().Add(entity);
            SaveChanges();
        }

        public void Update(T existing,T entity)
        {
            // In case AsNoTracking is used
            DataContext.Entry(existing).State = EntityState.Detached;
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
