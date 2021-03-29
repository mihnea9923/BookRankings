using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.BusinessLogic
{
    public class UserLikeService : Service<UserLike>
    {
        private readonly IUserLikeRepository repository;

        public UserLikeService(IUserLikeRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public bool Liked(Guid postId , Guid userId)
        {
            return repository.Liked(postId , userId) != null;
        }

        public void RemoveLike(Guid postId, Guid userId)
        {
            var userLike = repository.Get(postId, userId);
            repository.Remove(userLike.Id);
        }
    }
}
