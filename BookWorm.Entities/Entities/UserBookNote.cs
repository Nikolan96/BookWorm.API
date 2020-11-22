using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("UserBookNote")]
    public class UserBookNote : EntityBase
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
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
