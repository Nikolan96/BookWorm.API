using BookWorm.Contracts.Services;
using BookWorm.Entities.Entities;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm.Quartz.Jobs
{
    public class PickOfTheWeekJob : IJob
    {
        private const int NumberOfBooks = 10;
        private IPickOfTheWeekService _pickOfTheWeekService;
        private IBookService _bookService;
        private Random _rnd = new Random();

        public Task Execute(IJobExecutionContext context)
        {
            List<Guid> newPicksOfTheWeekIds = new List<Guid>();
            List<PickOfTheWeek> oldPicksOfTheWeek = new List<PickOfTheWeek>();

            _pickOfTheWeekService = context.JobDetail.JobDataMap.Get("PickOfTheWeekService") as IPickOfTheWeekService;
            _bookService = context.JobDetail.JobDataMap.Get("BookService") as IBookService;

            RemoveOldPicksOfTheWeek(oldPicksOfTheWeek);
            ChooseNewPicksOfTheWeek(newPicksOfTheWeekIds, oldPicksOfTheWeek);
            AddNewPicksOfTheWeek(newPicksOfTheWeekIds);

            return Task.CompletedTask;
        }

        private void AddNewPicksOfTheWeek(List<Guid> newPicksOfTheWeekIds)
        {
            foreach (var pickId in newPicksOfTheWeekIds)
            {
                var newPickOfTheWeek = new PickOfTheWeek
                {
                    BookId = pickId
                };

                _pickOfTheWeekService.AddPickOfTheWeek(newPickOfTheWeek);
            }
        }

        private void ChooseNewPicksOfTheWeek(List<Guid> newPicksOfTheWeekIds, List<PickOfTheWeek> oldPicksOfTheWeek)
        {
            while (newPicksOfTheWeekIds.Count < NumberOfBooks)
            {
                var books = _bookService.AsQueryable().ToList();
                var randomBookid = books[_rnd.Next(0, books.Count - 1)].Id;

                bool alreadyAdded = !newPicksOfTheWeekIds.Any(x => x == randomBookid);
                bool wasPickOfTheWeek = !oldPicksOfTheWeek.Any(y => y.BookId == randomBookid);

                if (alreadyAdded && wasPickOfTheWeek)
                {
                    newPicksOfTheWeekIds.Add(randomBookid);
                }
            }
        }

        private void RemoveOldPicksOfTheWeek(List<PickOfTheWeek> oldPicksOfTheWeek)
        {
            var picksOfTheWeek = _pickOfTheWeekService
                                .AsQueryable()
                                .ToList();

            foreach (var pick in picksOfTheWeek)
            {
                oldPicksOfTheWeek.Add(pick);
                _pickOfTheWeekService.RemovePickOfTheWeek(pick);
            }
        }
    }
}
