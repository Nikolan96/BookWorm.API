using System;
using System.ComponentModel.DataAnnotations;

namespace BookWorm.Entities.Base
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
