using BookWorm.Quartz.Triggers;
using Quartz;
using System.Collections.Generic;

namespace BookWorm.Quartz.Interfaces
{
    public interface IQuartzTriggerFactory
    {
        IEnumerable<ITrigger> Create(Trigger trigger);

        IEnumerable<ITrigger> GetOccuringInSeconds(int seconds);

        IEnumerable<ITrigger> GetOccuringInMinutes(int minutes);
    }
}
