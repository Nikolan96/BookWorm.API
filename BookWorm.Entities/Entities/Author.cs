using BookWorm.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("Author")]
    public class Author : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
        public ICollection<AuthorFact> AuthorFacts { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
