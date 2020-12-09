using BookWorm.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("Achievement")]
    public class Achievement : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        // Ef core relations

        [JsonIgnore]
        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
