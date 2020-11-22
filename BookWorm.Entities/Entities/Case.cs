using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("Case")]
    public class Case : EntityBase
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Title { get; set; }
        public int NumberOfBooks { get; set; }

        // EF Core relations

        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<BookCase> BookCases { get; set; }
    }
}
