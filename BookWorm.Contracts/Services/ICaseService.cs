using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface ICaseService
    {
        Case AddCase(Case @case);
        void RemoveCase(Case @case);
        Case UpdateCase(Case existing, Case @case);
        IQueryable<Case> AsQueryable();
    }
}