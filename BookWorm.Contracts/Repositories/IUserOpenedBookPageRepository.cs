using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Repositories
{
    public interface IUserOpenedBookPageRepository
    {
        void AddUserOpenedBookPage(UserOpenedBookPage entity);
        void RemoveUserOpenedBookPage(UserOpenedBookPage entity);
        void UpdateUserOpenedBookPage(UserOpenedBookPage existing, UserOpenedBookPage entity);
        IQueryable<UserOpenedBookPage> AsQueryable();
    }
}
