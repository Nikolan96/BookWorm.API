using BookWorm.Contracts.Enums;
using System;

namespace BookWorm.Contracts.Services
{
    public interface ILevelingService
    {
        int AddExperience(Guid userId, Activity activity);
    }
}