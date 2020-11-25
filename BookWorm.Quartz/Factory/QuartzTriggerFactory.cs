using BookWorm.Quartz.Extensions;
using BookWorm.Quartz.Interfaces;
using BookWorm.Quartz.Triggers;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.Quartz.Factory
{
    public class QuartzTriggerFactory : IQuartzTriggerFactory
    {
        public IEnumerable<ITrigger> Create(Trigger trigger)
        {
            if (trigger == null)
            {
                return Enumerable.Empty<ITrigger>();
            }

            var quartzTriggers = CreateTrigger(trigger);
            return quartzTriggers;
        }

        private static IEnumerable<ITrigger> CreateTrigger(Trigger trigger)
        {
            var triggerBuilder = DailyTimeIntervalScheduleBuilder.Create();
            var builder = TriggerBuilder.Create()
                .StartAt(DateTime.Now.AddSeconds(30))
                .WithSchedule(triggerBuilder)
                .EndAt(trigger.IsEndDateEnabled ? trigger.EndDate.EndOfTheDay() : (DateTimeOffset?)null);

            if (trigger.OccursOnce)
            {
                triggerBuilder.DailyTriggerOnce(
                    trigger.OccursOnceAtTicks.CastTimeOfDay(),
                    (trigger.SelectedDays()))
                    .WithMisfireHandlingInstructionDoNothing();

                return builder.Build().ToEnumerable();
            }
            else
            {
                triggerBuilder.DailyTriggerReccuring(
                    trigger.Interval,
                    (IntervalUnit)trigger.IntervalUnit,
                    trigger.StartTimeOfDayTicks.CastTimeOfDay(),
                    trigger.EndTimeOfDayTicks.CastTimeOfDay(),
                    (trigger.SelectedDays()))
                    .WithMisfireHandlingInstructionDoNothing();

                return builder.Build().ToEnumerable();
            }
        }

        public IEnumerable<ITrigger> GetOccuringInSeconds(int seconds)
        {
            var trigger = new Trigger
            {
                OccursOnce = false,
                Interval = seconds,
                IntervalUnit = TriggerTimeUnit.Second,
                StartTimeOfDayTicks = Trigger.Midnight.Ticks,
                EndTimeOfDayTicks = Trigger.AlmostMidnight.Ticks,
            };

            return Create(trigger);
        }

        public IEnumerable<ITrigger> GetOccuringInMinutes(int minutes)
        {
            var trigger = new Trigger
            {
                OccursOnce = false,
                Interval = minutes,
                IntervalUnit = TriggerTimeUnit.Minute,
                StartTimeOfDayTicks = DateTime.Now.Ticks,
                EndTimeOfDayTicks = Trigger.AlmostMidnight.Ticks,
            };

            return Create(trigger);
        }
    }
}
