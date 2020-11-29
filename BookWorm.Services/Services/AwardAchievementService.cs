using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using System;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class AwardAchievementService : IAwardAchievementService
    {
        private readonly IAchievementService _achievementService;
        private readonly IUserAchievementService _userAchievementService;
        private readonly IBooksReadService _booksReadService;

        public AwardAchievementService(IAchievementService achievementService,
            IUserAchievementService userAchievementService,
            IBooksReadService booksReadService)
        {
            _achievementService = achievementService;
            _userAchievementService = userAchievementService;
            _booksReadService = booksReadService;
        }

        public Achievement AwardAchievement(string achieTitle, Guid userId)
        {
            var existingAchie = _achievementService
                .AsQueryable()
                .Where(x => x.Title == achieTitle)
                .FirstOrDefault();

            if (existingAchie is null)
            {
                throw new Exception($"Achievement with title {achieTitle} does not exist!");
            }

            var userHasAchievement = _userAchievementService
                .AsQueryable()
                .Any(x => x.AchievementId == existingAchie.Id && x.UserId == userId);

            if (!userHasAchievement)
            {
                if (EligibleForAchievement(achieTitle, userId))
                {
                    var userAchie = new UserAchievement
                    {
                        AchievementId = existingAchie.Id,
                        UserId = userId
                    };

                    var achie = existingAchie;

                    _userAchievementService.AddUserAchievement(userAchie);
                    return achie;
                }
            }

            return null;
        }

        private bool EligibleForAchievement(string achieTitle, Guid userId)
        {
            switch (achieTitle)
            {
                case "Read one book":
                    return ReadOneBook(userId);
                default:
                    return false;
            }
        }

        private bool ReadOneBook(Guid userId)
        {
            var count = _booksReadService
                .AsQueryable()
                .Where(x => x.UserId == userId)
                .Count();

            if (count >= 1)
            {
                return true;
            }

            return false;
        }

    }
}
