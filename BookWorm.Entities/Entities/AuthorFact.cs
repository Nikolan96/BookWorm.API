using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("AuthorFact")]
    public class AuthorFact : EntityBase
    {
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public string Text { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }

        // EF Core relations
        [ForeignKey("AuthorId")]
        [JsonIgnore]
        public virtual Author Author { get; set; }
    }
}
