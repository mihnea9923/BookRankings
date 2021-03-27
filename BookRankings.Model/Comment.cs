using System;
using System.Collections.Generic;

namespace BookRankings.Model
{
    public class Comment
    {
        public Guid Id { get; set; }
        public int DepthLevel { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public List<Comment> Subcomments { get; set; } = new List<Comment>();
    }
}