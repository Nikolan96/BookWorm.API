using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{ 
    [Table("Book")]
    public class Book : EntityBase
    {
        [Required]
        public string ISBN { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Cover { get; set; }

        // EF Core relations
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookCase> BookCases { get; set; }
        public virtual ICollection<BookFact> BookFacts { get; set; }
        public virtual ICollection<CriticReview> CriticReviews { get; set; }
        public virtual ICollection<UserReview> UserReviews { get; set; }
        public virtual ICollection<UserBookNote> UserBookNotes { get; set; }
    }
}
