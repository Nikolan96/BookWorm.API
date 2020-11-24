using BookWorm.Contracts.Services;
using BookWorm.Quartz.Interfaces;
using BookWorm.Quartz.Jobs;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookWorm.Quartz.Services
{
    public class QuartzHostedService : IHostedService
    {
        private const int Interval = 10;

        private IScheduler _scheduler;
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IQuartzTriggerFactory _triggerFactory;
        private readonly IBookService _bookService;
        private readonly IPickOfTheDayService _pickOfTheDayService;

        public QuartzHostedService(ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory,
            IQuartzTriggerFactory quartzTriggerFactory,
            IBookService bookService,
            IPickOfTheDayService pickOfTheDayService)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _triggerFactory = quartzTriggerFactory;
            _bookService = bookService;
            _pickOfTheDayService = pickOfTheDayService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            _scheduler.JobFactory = _jobFactory;

            await SchedulePickOfTheDayJob(cancellationToken);

            await _scheduler.Start(cancellationToken);
        }

        private async Task SchedulePickOfTheDayJob(CancellationToken cancellationToken)
        {
            IJobDetail jobDetail = JobBuilder.Create<PickOfTheDayJob>()
                            .WithIdentity(new JobKey(Guid.NewGuid().ToString()))
                            .Build();

            jobDetail.JobDataMap.Add("PickOfTheDayService", _pickOfTheDayService);
            jobDetail.JobDataMap.Add("BookService", _bookService);

            var triggers = new HashSet<ITrigger>(_triggerFactory.GetOccuringInMinutes(Interval));
            await _scheduler.ScheduleJob(jobDetail, triggers, true, cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _scheduler?.Shutdown(cancellationToken);
        }
    }
}