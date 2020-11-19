using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IRoleRepository
    {
        void AddRole(Role entity);
        void RemoveRole(Role entity);
        void UpdateRole(Role existing, Role entity);
        IQueryable<Role> AsQueryable();
    }
}
