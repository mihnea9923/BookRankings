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

        public Comment[] Dfs(List<Comment> comments)
        {
            Stack<Comment> commentsStack = new Stack<Comment>();
            foreach (var it in comments)
                DfsUtil(it, commentsStack);
            return commentsStack.ToArray();
        }

        private void DfsUtil(Comment comment , Stack<Comment> comments)
        {
            if (comment == null)
                return;
            foreach(var it in comment.Subcomments)
            {
                it.User.Ratings = null;
                comments.Push(it);
                DfsUtil(it, comments);
            }
        }
    }
}
