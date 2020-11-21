using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("PickOfTheDay")]
    public class PickOfTheDay : EntityBase
    {
        public Guid BookId { get; set; }
    }
}
