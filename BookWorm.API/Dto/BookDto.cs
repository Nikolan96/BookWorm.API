using BookWorm.Entities.Base;
using System;

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
        public string Author { get; set; }
    }
}
