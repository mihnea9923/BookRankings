using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.BusinessLogic
{
    public class CommentService : Service<Comment>
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository) : base(commentRepository)
        {
            this.commentRepository = commentRepository;
        }
    }
}
