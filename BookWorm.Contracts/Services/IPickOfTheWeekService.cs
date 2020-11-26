using BookWorm.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWorm.Contracts.Services
{
    public interface IPickOfTheWeekService
    {
        PickOfTheWeek AddPickOfTheWeek(PickOfTheWeek pickOfTheWeek);
        void RemovePickOfTheWeek(PickOfTheWeek pickOfTheWeek);
        PickOfTheWeek UpdatePickOfTheWeek(PickOfTheWeek existing, PickOfTheWeek pickOfTheWeek);
        IQueryable<PickOfTheWeek> AsQueryable();
    }
}
