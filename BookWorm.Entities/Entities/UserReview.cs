using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("UserReview")]
    public class UserReview : EntityBase
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int Rating { get; set; }


        // EF Core relations

        [ForeignKey("BookId")]
        [JsonIgnore]
        public virtual Book Book { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
