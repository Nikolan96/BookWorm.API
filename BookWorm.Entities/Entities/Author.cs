using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("Author")]
    public class Author : EntityBase
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int BooksPublished { get; set; }
        [Required]
        public string ShortBio { get; set; }

        // EF Core relations
        public virtual ICollection<AuthorFact> AuthorFacts { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
