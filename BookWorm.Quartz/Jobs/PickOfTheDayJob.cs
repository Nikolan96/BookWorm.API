using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm.Quartz.Jobs
{
    public class PickOfTheDayJob : IJob
    {
        private const int NumberOfBooks = 10;
        private readonly IPickOfTheDayService _pickOfTheDayService;
        private readonly IBookService _bookService;
        private Random _rnd = new Random();

        public Task Execute(IJobExecutionContext context)
        {
            List<Guid> newPicksOfTheDayIds = new List<Guid>();
            List<PickOfTheDay> oldPicksOfTheDay = new List<PickOfTheDay>();

            var pickOfTheDayService = context.JobDetail.JobDataMap.Get("PickOfTheDayService") as IPickOfTheDayService;
            var bookService = context.JobDetail.JobDataMap.Get("BookService") as IBookService;

            RemoveOldPicksOfTheDay(oldPicksOfTheDay, pickOfTheDayService);
            ChooseNewPicksOfTheDay(newPicksOfTheDayIds, oldPicksOfTheDay, bookService);
            AddNewPicksOfTheDay(newPicksOfTheDayIds, pickOfTheDayService);

            return Task.CompletedTask;
        }

        private void AddNewPicksOfTheDay(List<Guid> newPicksOfTheDayIds, IPickOfTheDayService pickOfTheDayService)
        {
            foreach (var pickId in newPicksOfTheDayIds)
            {
                var newPickOfTheDay = new PickOfTheDay
                {
                    BookId = pickId
                };

                pickOfTheDayService.AddPickOfTheDay(newPickOfTheDay);
            }
        }

        private void ChooseNewPicksOfTheDay(List<Guid> newPicksOfTheDayIds, List<PickOfTheDay> oldPicksOfTheDay, IBookService bookService)
        {
            while (newPicksOfTheDayIds.Count < NumberOfBooks)
            {
                var books = bookService.AsQueryable().ToList();
                var randomBookid = books[_rnd.Next(0, books.Count - 1)].Id;

                bool alreadyAdded = !newPicksOfTheDayIds.Any(x => x == randomBookid);
                bool wasPickOfTheDay = !oldPicksOfTheDay.Any(y => y.BookId == randomBookid);

                if (alreadyAdded && wasPickOfTheDay)
                {
                    newPicksOfTheDayIds.Add(randomBookid);
                }
            }
        }

        private void RemoveOldPicksOfTheDay(List<PickOfTheDay> oldPicksOfTheDay, IPickOfTheDayService pickOfTheDayService)
        {
            var picksOfTheDay = pickOfTheDayService
                                .AsQueryable()
                                .ToList();

            foreach (var pick in picksOfTheDay)
            {
                oldPicksOfTheDay.Add(pick);
                pickOfTheDayService.RemovePickOfTheDay(pick);
            }
        }
    }
}
