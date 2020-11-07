using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("BookFact")]
    public class BookFact : EntityBase
    {
        public Guid BookId { get; set; }

        // EF Core relations

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
