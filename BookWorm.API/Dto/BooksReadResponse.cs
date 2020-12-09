using BookWorm.Entities.Entities;
using System.Collections.Generic;

namespace BookWorm.API.Dto
{
    public class BooksReadResponse
    {
        public List<BooksRead> BooksRead { get; set; } = new List<BooksRead>();
        public List<Achievement> Achievements { get; set; }
        public LevelupResponse LevelupResponse { get; set; }
    }
}
