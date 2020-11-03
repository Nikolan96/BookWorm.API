using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface ICaseRepository
    {
        void AddCase(Case entity);
        void RemoveCase(Case entity);
        void UpdateCase(Case existing, Case entity);
        IQueryable<Case> AsQueryable();
    }
}