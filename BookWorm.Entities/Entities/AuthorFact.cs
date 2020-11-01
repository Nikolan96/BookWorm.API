using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookWorm.Entities.Entities
{
    [Table("AuthorFact")]
    public class AuthorFact : EntityBase
    {

        public Guid AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}
