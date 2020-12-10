using BookWorm.Entities.Base;
using BookWorm.Entities.Entities;
using System;
using System.Collections.Generic;

namespace BookWorm.API.Dto
{
    public class BookDto : EntityBase
    {
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public int NumberOfPages { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public List<AuthorDto> Authors { get; set; }
    }
}
