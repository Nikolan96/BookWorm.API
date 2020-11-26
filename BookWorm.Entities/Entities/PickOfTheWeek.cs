using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("PickOfTheWeek")]
    public class PickOfTheWeek : EntityBase
    {
        public Guid BookId { get; set; }
    }
}
