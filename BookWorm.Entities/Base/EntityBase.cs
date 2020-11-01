using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookWorm.Entities.Base
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
