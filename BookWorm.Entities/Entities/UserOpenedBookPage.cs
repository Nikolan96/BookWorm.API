using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("UserOpenedBookPage")]
    public class UserOpenedBookPage : EntityBase
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }


        // EF Core relations
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
