using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Repositories
{
    public interface ICaseRepository
    {
        void AddCase(Case entity);
        void RemoveCase(Case entity);
        void UpdateCase(Case entity);
    }
}