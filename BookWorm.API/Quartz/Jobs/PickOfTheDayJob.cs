using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm.API.Quartz.Jobs
{
    [DisallowConcurrentExecution]
    public class PickOfTheDayJob : IJob
    {
        private const int NumberOfBooks = 10;
        private readonly IServiceProvider _provider;
        public PickOfTheDayJob(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Task Execute(IJobExecutionContext context)
        {
            List<Guid> newPicksOfTheDayIds = new List<Guid>();
            List<PickOfTheDay> oldPicksOfTheDay = new List<PickOfTheDay>();
            var rnd = new Random();

            using (var scope = _provider.CreateScope())
            {
                var pickOfTheDayService = scope.ServiceProvider.GetService<IPickOfTheDayService>();
                var bookService = scope.ServiceProvider.GetService<IBookService>();

                var picksOfTheDay = pickOfTheDayService
                    .AsQueryable()
                    .ToList();

                // remove old picks of the day
                foreach (var pick in picksOfTheDay)
                {
                    oldPicksOfTheDay.Add(pick);
                    pickOfTheDayService.RemovePickOfTheDay(pick);
                }

                // choose new picks of the day
                while (newPicksOfTheDayIds.Count < 10)
                {
                    var books = bookService.AsQueryable().ToList();
                    var randomBookid = books[rnd.Next(0, books.Count - 1)].Id;

                    bool alreadyAdded = !newPicksOfTheDayIds.Any(x => x == randomBookid);
                    bool wasPickOfTheDay = !oldPicksOfTheDay.Any(y => y.BookId == randomBookid);

                    if (alreadyAdded && wasPickOfTheDay)
                    {
                        newPicksOfTheDayIds.Add(randomBookid);
                    }
                }

                // add new picks of the day
                foreach (var pickId in newPicksOfTheDayIds)
                {
                    var newPickOfTheDay = new PickOfTheDay
                    {
                        BookId = pickId
                    };

                    pickOfTheDayService.AddPickOfTheDay(newPickOfTheDay);
                }
            }
            return Task.CompletedTask;
        }
    }
}
