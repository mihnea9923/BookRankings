using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.Model
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PostedDate { get; set; }
        public int Likes { get; set; }
        public int CommentsNr { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
