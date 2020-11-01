using BookWorm.Contracts.Wrapper;
using BookWorm.Entities.Entities;
using BookWorm.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWorm.Services.Services
{
    public class CaseService : ICaseService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CaseService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            //_logger = logger;
        }

        public Case AddCase(Case @case)
        {
            _repositoryWrapper.Case.AddCase(@case);
            //_logger.WriteInfo($"Added user with id: {user.Id}.");

            return @case;
        }

        public void RemoveCase(Case @case)
        {
            _repositoryWrapper.Case.RemoveCase(@case);
            // _logger.WriteInfo($"Removed user with id: {user.Id}.");
        }

        public Case UpdateCase(Case @case)
        {
            _repositoryWrapper.Case.UpdateCase(@case);
            // _logger.WriteInfo($"Updated user with id: {user.Id}.");

            return @case;
        }
    }
}
