using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("BookAuthor")]
    public class BookAuthor : EntityBase
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }


        // EF Core relations

        [ForeignKey("BookId")]
        [JsonIgnore]
        public virtual Book Book { get; set; }
        [ForeignKey("AuthorId")]
        [JsonIgnore]
        public virtual Author Author { get; set; }
    }
}
