using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.DataAcess.Abstractions
{
    public interface IUserLikeRepository : IRepository<UserLike>
    {
        UserLike Liked(Guid postId, Guid userId);
        UserLike Get(Guid postId, Guid userId);
    }
}
