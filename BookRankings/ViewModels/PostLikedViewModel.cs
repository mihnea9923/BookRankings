using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRankings.ViewModels
{
    public class PostLikedViewModel
    {
        public bool Liked { get; set; }
        public Post Post { get; set; }
    }
}
