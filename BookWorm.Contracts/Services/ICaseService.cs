using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface ICaseService
    {
        Case AddCase(Case @case);
        void RemoveCase(Case @case);
        Case UpdateCase(Case @case);
    }
}