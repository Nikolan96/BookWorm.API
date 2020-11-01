using BookWorm.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("User")]
    public class User : EntityBase
    {



        public ICollection<UserReview> UserReviews { get; set; }
        public ICollection<Case> Cases { get; set; }
    }
}
