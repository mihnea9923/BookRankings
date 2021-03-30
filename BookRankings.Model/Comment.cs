using System;
using System.Collections.Generic;

namespace BookRankings.Model
{
    public class Comment
    {
        public Guid Id { get; set; }
        public int DepthLevel { get; set; }
        public string Content { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual User User { get; set;  }
        public Guid? ParentId { get; set; }
        public virtual List<Comment> Subcomments { get; set; } 

        public void Add(Comment comment)
        {
            if (Subcomments == null)
                Subcomments = new List<Comment>();
            Subcomments.Add(comment);
        }
    }
}