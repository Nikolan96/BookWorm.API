using BookWorm.Quartz.Triggers;
using System;
using System.Collections.Generic;

namespace BookWorm.Quartz.Extensions
{
    public static class TriggerExtension
    {
        public static IEnumerable<DayOfWeek> SelectedDays(this Trigger trigger)
        {
            if (trigger.OnMonday)
            {
                yield return DayOfWeek.Monday;
            }
            if (trigger.OnTuesday)
            {
                yield return DayOfWeek.Tuesday;
            }
            if (trigger.OnWednesday)
            {
                yield return DayOfWeek.Wednesday;
            }
            if (trigger.OnThursday)
            {
                yield return DayOfWeek.Thursday;
            }
            if (trigger.OnFriday)
            {
                yield return DayOfWeek.Friday;
            }
            if (trigger.OnSaturday)
            {
                yield return DayOfWeek.Saturday;
            }
            if (trigger.OnSunday)
            {
                yield return DayOfWeek.Sunday;
            }
        }
    }
}
