using BookWorm.Contracts.Services;
using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWorm.Services.Services
{
    public class UserCurrentlyReadingService : IUserCurrentlyReadingService
    {
        //private readonly ILogger<UserService> _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserCurrentlyReadingService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public IQueryable<UserCurrentlyReading> AsQueryable()
        {
            return _repositoryWrapper.UserCurrentlyReading.AsQueryable();
        }

        public UserCurrentlyReading AddUserCurrentlyReading(UserCurrentlyReading UserCurrentlyReading)
        {
            _repositoryWrapper.UserCurrentlyReading.AddUserCurrentlyReading(UserCurrentlyReading);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return UserCurrentlyReading;
        }

        public void RemoveUserCurrentlyReading(UserCurrentlyReading UserCurrentlyReading)
        {
            _repositoryWrapper.UserCurrentlyReading.RemoveUserCurrentlyReading(UserCurrentlyReading);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public UserCurrentlyReading UpdateUserCurrentlyReading(UserCurrentlyReading existing, UserCurrentlyReading UserCurrentlyReading)
        {
            _repositoryWrapper.UserCurrentlyReading.UpdateUserCurrentlyReading(existing, UserCurrentlyReading);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return UserCurrentlyReading;
        }
    }
}