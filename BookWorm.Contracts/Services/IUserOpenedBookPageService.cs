using BookWorm.Entities.Entities;
using System.Linq;

namespace BookWorm.Contracts.Services
{
    public interface IUserOpenedBookPageService
    {
        UserOpenedBookPage AddUserOpenedBookPage(UserOpenedBookPage userOpenedBookPage);
        void RemoveUserOpenedBookPage(UserOpenedBookPage userOpenedBookPage);
        UserOpenedBookPage UpdateUserOpenedBookPage(UserOpenedBookPage existing, UserOpenedBookPage userOpenedBookPage);
        IQueryable<UserOpenedBookPage> AsQueryable();
    }
}
