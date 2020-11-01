using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookWorm.Entities.Entities
{
    [Table("Author")]
    public class Author : EntityBase
    {



        public ICollection<AuthorFact> AuthorFacts { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
