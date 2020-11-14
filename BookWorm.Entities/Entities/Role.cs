using BookWorm.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("Role")]
    public class Role : EntityBase
    {
        [Required]
        public string Name { get; set; }

        // EF Core relations
        public virtual ICollection<User> Users { get; set; }
    }
}
