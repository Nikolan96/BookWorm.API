using BookWorm.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("Address")]
    public class Address : EntityBase
    {
        [Required]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required]
        public string City { get; set; }
        public string County_Province { get; set; }
        public string Zip_Or_Postcode { get; set; }
        [Required]
        public string Country { get; set; }
        public string Other_Address_Details { get; set; }


        // EF Core relations
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
