using System;
using System.Collections.Generic;

namespace BookWorm.API.Requests
{
    public class BooksReadRequest
    {
        public Guid? UserId { get; set; }
        public List<Guid> BookIds { get; set; }
    }
}
