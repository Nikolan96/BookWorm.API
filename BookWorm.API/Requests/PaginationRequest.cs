using System.ComponentModel.DataAnnotations;

namespace BookWorm.API.Requests
{
    public class PaginationRequest
    {
        [Required]
        public int Page { get; set; }
        [Required]
        public int ItemsPerPage { get; set; }
    }
}
