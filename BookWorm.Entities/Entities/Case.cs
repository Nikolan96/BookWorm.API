using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("Case")]
    public class Case : EntityBase
    {
        public Guid UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int NumberOfBooks { get; set; }

        // EF Core relations

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<BookCase> BookCases { get; set; }
    }
}
