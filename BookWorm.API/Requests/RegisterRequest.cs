using BookWorm.Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookWorm.API.Requests
{
    public class RegisterRequest
    {
        [Required]
        public UserRegistrationRequest UserRegistration { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
