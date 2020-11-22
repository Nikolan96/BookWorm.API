using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("BooksRead")]
    public class BooksRead : EntityBase
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }

        // EF Core relations

        [ForeignKey("BookId")]
        [JsonIgnore]
        public virtual Book Book { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
