using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public RoleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<Role> AsQueryable()
        {
            return _repositoryWrapper.Role.AsQueryable();
        }

        public Role AddRole(Role role)
        {
            _repositoryWrapper.Role.AddRole(role);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return role;
        }

        public void RemoveRole(Role role)
        {
            _repositoryWrapper.Role.RemoveRole(role);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public Role UpdateRole(Role existing, Role role)
        {
            _repositoryWrapper.Role.UpdateRole(existing, role);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return role;
        }
    }
}
