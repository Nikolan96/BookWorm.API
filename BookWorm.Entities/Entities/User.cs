using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("User")]
    public class User : EntityBase
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Guid AddressId { get; set; }
        public Guid RoleId { get; set; }


        // EF Core relations
        [ForeignKey("AddressId")]
        [JsonIgnore]
        public Address Address { get; set; }

        [ForeignKey("RoleId")]
        [JsonIgnore]
        public Role Role { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserReview> UserReviews { get; set; }
        [JsonIgnore]
        public virtual ICollection<Case> Cases { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserBookNote> UserBookNotes { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserOpenedBookPage> UserOpenedBookPages { get; set; }
        [JsonIgnore]
        public virtual ICollection<BooksRead> BooksRead { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
