using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWorm.Services.Services
{
    public class ReasonToReadService : IReasonToReadService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ReasonToReadService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public ReasonToRead AddReasonToRead(ReasonToRead reasonToRead)
        {
            _repositoryWrapper.ReasonToRead.AddReasonToRead(reasonToRead);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return reasonToRead;
        }

        public void RemoveReasonToRead(ReasonToRead reasonToRead)
        {
            _repositoryWrapper.ReasonToRead.RemoveReasonToRead(reasonToRead);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public ReasonToRead UpdateReasonToRead(ReasonToRead reasonToRead)
        {
            _repositoryWrapper.ReasonToRead.UpdateReasonToRead(reasonToRead);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return reasonToRead;
        }
    }
}
