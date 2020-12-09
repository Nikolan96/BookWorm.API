using BookWorm.Contracts.Enums;
using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.Services.Services
{
    public class LevelingService : ILevelingService
    {
        private const int MaxLevel = 10;
        private readonly IUserService _userService;
        private Dictionary<Activity, int> _xpForActivity;
        private Dictionary<int, int> _xpForLevel;

        public LevelingService(IUserService userService)
        {
            _userService = userService;

            InitXPForActivity();
            InitXPForLevel();
        }

        private void InitXPForActivity()
        {
            _xpForActivity = new Dictionary<Activity, int>();

            _xpForActivity.Add(Activity.AddedNote, 2);
            _xpForActivity.Add(Activity.AddedReview, 5);
            _xpForActivity.Add(Activity.CreatedCase, 3);
            _xpForActivity.Add(Activity.ReadBook, 5);
            _xpForActivity.Add(Activity.ReadHundredPages, 3);
        }

        private void InitXPForLevel()
        {
            _xpForLevel = new Dictionary<int, int>();

            _xpForLevel.Add(2, 10);
            _xpForLevel.Add(3, 20);
            _xpForLevel.Add(4, 30);
            _xpForLevel.Add(5, 40);
            _xpForLevel.Add(6, 50);
            _xpForLevel.Add(7, 60);
            _xpForLevel.Add(8, 70);
            _xpForLevel.Add(9, 80);
            _xpForLevel.Add(10, 100);
        }

        public int AddExperience(Guid userId, Activity activity)
        {
            var user = _userService
                .AsQueryable()
                .FirstOrDefault(x => x.Id == userId);

            if (user is null)
            {
                throw new Exception($"User with id {userId} does not exist!");
            }

            return CheckIfLvlUp(user, activity);
        }

        private int CheckIfLvlUp(User user, Activity activity)
        {
            // TODO : what if user earns enough xp for more than one lvl up

            int lvl = 0;

            if (user.CurrentLevel != MaxLevel)
            {
                var totalXpNeededForNextLvl = _xpForLevel[user.NextLevel];

                user.Experience += _xpForActivity[activity];

                if (user.Experience > totalXpNeededForNextLvl)
                {
                    user.Experience -= totalXpNeededForNextLvl;
                    lvl = LevelUp(user);
                }
                else if (user.Experience == totalXpNeededForNextLvl)
                {
                    user.Experience = 0;
                    lvl = LevelUp(user);
                }

                var existingUser = _userService.AsQueryable().FirstOrDefault(x => x.Id == user.Id);
                _userService.UpdateUser(existingUser, user);
            }

            return lvl;
        }

        private int LevelUp(User user)
        {
            user.CurrentLevel = user.NextLevel;
            user.NextLevel += 1;

            return user.CurrentLevel;
        }
    }
}
