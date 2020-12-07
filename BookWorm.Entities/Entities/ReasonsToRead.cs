using BookWorm.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("ReasonsToRead")]
    public class ReasonsToRead : EntityBase
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Cover { get; set; }
    }
}
