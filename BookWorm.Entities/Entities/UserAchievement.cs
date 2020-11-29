using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    public class UserAchievement : EntityBase
    {
        public Guid UserId { get; set; }
        public Guid AchievementId { get; set; }

        // EF core relationship

        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User User { get; set; }
        [ForeignKey("AchievementId")]
        [JsonIgnore]
        public virtual Achievement Achievement { get; set; }
    }
}
