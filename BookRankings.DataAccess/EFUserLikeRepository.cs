using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookRankings.DataAccess
{
    public class EFUserLikeRepository : EFRepository<UserLike>, IUserLikeRepository
    {
        private readonly BooksDbContext context;

        public EFUserLikeRepository(BooksDbContext context) : base(context)
        {
            this.context = context;
        }

        public UserLike Get(Guid postId, Guid userId)
        {
            return context.UserLikes.Where(it => it.User.Id == userId && it.Post.Id == postId).FirstOrDefault();
        }

        public UserLike Liked(Guid postId , Guid userId)
        {
            return context.UserLikes.Where(it => it.Post.Id == postId && it.User.Id == userId).FirstOrDefault() ;
        }
    }
}
