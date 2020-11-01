using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("BookAuthor")]
    public class BookAuthor : EntityBase
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}
