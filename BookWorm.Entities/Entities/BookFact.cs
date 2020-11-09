using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("BookFact")]
    public class BookFact : EntityBase
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public string Text { get; set; }

        // EF Core relations
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
