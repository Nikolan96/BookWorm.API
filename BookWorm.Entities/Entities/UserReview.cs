using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("UserReview")]
    public class UserReview : EntityBase
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
