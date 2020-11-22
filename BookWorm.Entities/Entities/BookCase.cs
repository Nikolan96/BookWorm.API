using BookWorm.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("BookCase")]
    public class BookCase : EntityBase
    {
        public Guid BookId { get; set; }
        public Guid CaseId { get; set; }

        // EF Core relations
        [ForeignKey("BookId")]
        [JsonIgnore]
        public virtual Book Book { get; set; }
        [ForeignKey("CaseId")]
        [JsonIgnore]
        public virtual Case Case { get; set; }
    }
}
