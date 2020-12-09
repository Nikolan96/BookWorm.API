using BookWorm.Entities.Entities;
using System.Collections.Generic;

namespace BookWorm.API.Dto
{
    public class UserBookNoteResponse
    {
        public UserBookNote UserBookNote { get; set; }
        public List<Achievement> Achievements { get; set; }
        public LevelupResponse LevelupResponse { get; set; }
    }
}
