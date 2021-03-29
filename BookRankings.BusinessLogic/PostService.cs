using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<Post> Search(string keyword)
        {
            Expression<Func<Post, bool>> filter = null;
            if (keyword != null && keyword != "")
            {
                filter = x => x.Content.ToLower().Contains(keyword) ||
                              x.Title.ToLower().Contains(keyword);
            }
            var posts = GetAll(filter).ToList();
            return posts;
        }
    }
}
