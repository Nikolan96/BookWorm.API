using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IRoleService
    {
        Role AddRole(Role role);
        void RemoveRole(Role role);
        Role UpdateRole(Role existing, Role role);
        IQueryable<Role> AsQueryable();
    }
}
