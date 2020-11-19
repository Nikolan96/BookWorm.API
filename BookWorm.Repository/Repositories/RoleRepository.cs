using BookWorm.Contracts.Repositories;
using BookWorm.Entities;
using BookWorm.Entities.Entities;
using BookWorm.Repository.Base;

namespace BookWorm.Repository.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public void AddRole(Role entity)
        {
            Add(entity);
        }

        public void RemoveRole(Role entity)
        {
            Remove(entity);
        }

        public void UpdateRole(Role existing, Role entity)
        {
            Update(existing, entity);
        }
    }
}
