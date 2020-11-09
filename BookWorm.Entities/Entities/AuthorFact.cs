using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("AuthorFact")]
    public class AuthorFact : EntityBase
    {
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public string Text { get; set; }

        // EF Core relations
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}
