using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.BusinessLogic
{
    public class PostService : Service<Post>
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository) : base(postRepository)
        {
            this.postRepository = postRepository;
        }
    }
}
