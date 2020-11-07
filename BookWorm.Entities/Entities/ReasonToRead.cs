using BookWorm.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("ReasonToRead")]
    public class ReasonToRead : EntityBase
    {
        [Required]
        public string Text { get; set; }
    }
}
