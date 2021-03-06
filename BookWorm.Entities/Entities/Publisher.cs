﻿using BookWorm.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookWorm.Entities.Entities
{
    [Table("Publisher")]
    public class Publisher : EntityBase
    {
        public string Name { get; set; }

        // EF Core relations
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}
