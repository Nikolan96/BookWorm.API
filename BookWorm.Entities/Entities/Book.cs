using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public string Cover { get; set; }

        [Required]
        public int NumberOfPages { get; set; }
      
        [Required]
        public Guid GenreId { get; set; }
        [Required]
        public Guid PublisherId { get; set; }

        // EF Core relations
        [JsonIgnore]
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        [JsonIgnore]
        public virtual ICollection<BookCase> BookCases { get; set; }
        [JsonIgnore]
        public virtual ICollection<BookFact> BookFacts { get; set; }
        [JsonIgnore]
        public virtual ICollection<CriticReview> CriticReviews { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserReview> UserReviews { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserBookNote> UserBookNotes { get; set; } 
        [JsonIgnore]
        public virtual ICollection<UserOpenedBookPage> UserOpenedBookPages { get; set; }
        [JsonIgnore]
        public virtual ICollection<BooksRead> BooksRead { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserCurrentlyReading> BooksUserIsCurrentlyReading { get; set; }


        [ForeignKey("GenreId")]
        [JsonIgnore]
        public virtual Genre Genre { get; set; }

        [ForeignKey("PublisherId")]
        [JsonIgnore]
        public virtual Publisher Publisher { get; set; }

        public override bool Equals(object obj)
        {
            var book = (Book)obj;
            return Id == book.Id;
        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode() ^
                Title.GetHashCode() ^
                Id.GetHashCode();
        }
    }
}
