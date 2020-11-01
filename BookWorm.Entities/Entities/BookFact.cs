﻿using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookWorm.Entities.Entities
{
    [Table("BookFact")]
    public class BookFact : EntityBase
    {

        public Guid BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
