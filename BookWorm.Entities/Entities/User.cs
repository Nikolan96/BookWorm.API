﻿using BookWorm.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Address { get; set; }

        // EF Core relations
        public virtual ICollection<UserReview> UserReviews { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<UserBookNote> UserBookNotes { get; set; }
    }
}
