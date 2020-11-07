using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("CriticReview")]
    public class CriticReview : EntityBase
    {
        public Guid BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public double Rating { get; set; }

        // EF Core relations
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
