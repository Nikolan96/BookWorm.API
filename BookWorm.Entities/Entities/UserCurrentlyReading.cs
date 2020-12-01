using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table ("UserCurrentlyReading")]
    public class UserCurrentlyReading : EntityBase
    {
        public Guid BookId { get; set; }

        public Guid UserId { get; set; }

        public int CurrentPage { get; set; }

        //EF Core Relations

        [ForeignKey("BookId")]
        [JsonIgnore]
        public virtual Book Book { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User User { get; set; }

    }

}
