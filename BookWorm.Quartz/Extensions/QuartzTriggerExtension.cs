using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.Quartz.Extensions
{
    public static class QuartzTriggerExtension
    {
        public static TriggerBuilder MonthlyTriggerOnDay(this TriggerBuilder builder,
            TimeOfDay fireTime,
            int dayOfMonth,
            int ofEvery)
        {
            builder.WithCronSchedule($"{fireTime.Second} {fireTime.Minute} {fireTime.Hour} {dayOfMonth} 1/{ofEvery} ? *");
            return builder;
        }

        public static DailyTimeIntervalScheduleBuilder DailyTriggerOnce(this DailyTimeIntervalScheduleBuilder builder,
            TimeOfDay fireTime,
            IEnumerable<DayOfWeek> onDaysOfWeek = null)
        {
            builder.StartingDailyAt(fireTime)
                .EndingDailyAfterCount(1)
                .OnDaysOfTheWeekIfAny(onDaysOfWeek);
            return builder;
        }

        public static DailyTimeIntervalScheduleBuilder DailyTriggerReccuring(this DailyTimeIntervalScheduleBuilder builder,
            int interval,
            IntervalUnit unit,
            TimeOfDay startTimeOfDay,
            TimeOfDay endTimeOfDay,
            IEnumerable<DayOfWeek> onDaysOfWeek = null)
        {
            builder.StartingDailyAt(startTimeOfDay)
                .EndingDailyAt(endTimeOfDay)
                .WithInterval(interval, unit)
                .OnDaysOfTheWeekIfAny(onDaysOfWeek);
            return builder;
        }

        private static DailyTimeIntervalScheduleBuilder OnDaysOfTheWeekIfAny(this DailyTimeIntervalScheduleBuilder builder,
            IEnumerable<DayOfWeek> onDaysOfWeek)
        {
            if (onDaysOfWeek != null && onDaysOfWeek.Any())
            {
                builder.OnDaysOfTheWeek(onDaysOfWeek.ToArray());
            }
            return builder;
        }

        public static TriggerBuilder TriggerDuration(this TriggerBuilder builder,
            DateTimeOffset startTime,
            DateTimeOffset? endTime = null)
        {
            builder
                .StartAt(startTime)
                .EndAt(endTime);
            return builder;
        }

        public static TimeOfDay CastTimeOfDay(this DateTime dateTime)
        {
            return new TimeOfDay(dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
        public static TimeOfDay CastTimeOfDay(this TimeSpan time)
        {
            return new TimeOfDay(time.Hours, time.Minutes, time.Seconds);
        }

        public static TimeOfDay CastTimeOfDay(this long timeTicks)
        {
            TimeSpan time = TimeSpan.FromTicks(timeTicks);
            return (new TimeOfDay(time.Hours, time.Minutes, time.Seconds));
        }

        public static DateTime BeginningOfTheDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 1);
        }

        public static DateTime EndOfTheDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }
    }
}
