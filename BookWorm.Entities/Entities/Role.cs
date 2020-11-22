using BookWorm.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("Role")]
    public class Role : EntityBase
    {
        [Required]
        public string Name { get; set; }

        // EF Core relations
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
