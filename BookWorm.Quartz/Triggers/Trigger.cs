using System;

namespace BookWorm.Quartz.Triggers
{
    public class Trigger
    {
        public static readonly TimeSpan Midnight = new TimeSpan(0, 0, 0);
        public static readonly TimeSpan Noon = new TimeSpan(12, 0, 0);
        public static readonly TimeSpan AlmostMidnight = new TimeSpan(23, 59, 59);
        public static readonly TimeSpan Morning = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan Evening = new TimeSpan(18, 0, 0);

        public bool IsEnabled { get; set; } = true;
        public bool OccursOnce { get; set; } = false;
        public long OccursOnceAtTicks { get; set; } = Noon.Ticks;
        public int Interval { get; set; } = 1;
        public TriggerTimeUnit IntervalUnit { get; set; } = TriggerTimeUnit.Hour;
        public long StartTimeOfDayTicks { get; set; } = Morning.Ticks;
        public long EndTimeOfDayTicks { get; set; } = AlmostMidnight.Ticks;
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today;
        public bool IsEndDateEnabled { get; set; } = false;

        public bool OnMonday { get; set; } = true;
        public bool OnTuesday { get; set; } = true;
        public bool OnWednesday { get; set; } = true;
        public bool OnThursday { get; set; } = true;
        public bool OnFriday { get; set; } = true;
        public bool OnSaturday { get; set; } = true;
        public bool OnSunday { get; set; } = true;
    }
}
