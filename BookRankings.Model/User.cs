using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
