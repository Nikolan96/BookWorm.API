using System;
using BookWorm.Entities.Entities;

namespace BookWorm.Contracts.Services
{
    public interface IAwardAchievementService
    {
        Achievement AwardAchievement(string achieTitle, Guid userId);
    }
}