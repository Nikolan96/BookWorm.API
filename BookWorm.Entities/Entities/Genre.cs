using BookWorm.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("Genre")]
    public class Genre : EntityBase
    {
        public string Name { get; set; }

        // EF Core relations

        public virtual ICollection<Book> Books { get; set; }
    }
}
