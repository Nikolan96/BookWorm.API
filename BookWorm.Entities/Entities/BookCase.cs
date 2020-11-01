using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookWorm.Entities.Entities
{
    [Table("BookCase")]
    public class BookCase : EntityBase
    {
        public Guid BookId { get; set; }
        public Guid CaseId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        [ForeignKey("CaseId")]
        public virtual Case Case { get; set; }
    }
}
