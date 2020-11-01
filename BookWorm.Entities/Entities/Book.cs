using BookWorm.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Entities.Entities
{
    [Table("Book")]
    public class Book : EntityBase
    {


        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookCase> BookCases { get; set; }
        public virtual ICollection<BookFact> BookFacts { get; set; }
        public virtual ICollection<CriticReview> CriticReviews { get; set; }
        public virtual ICollection<UserReview> UserReviews { get; set; }
    }
}
