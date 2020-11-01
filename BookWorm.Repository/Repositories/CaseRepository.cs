using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;
using BookWorm.Contracts.Repositories;

namespace BookWorm.Repository.Repositories
{
    public class CaseRepository : RepositoryBase<Case>, ICaseRepository
    {
        public CaseRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddCase(Case entity)
        {
            Add(entity);
        }

        public void RemoveCase(Case entity)
        {
            Remove(entity);
        }

        public void UpdateCase(Case entity)
        {
            Update(entity);
        }
    }
}