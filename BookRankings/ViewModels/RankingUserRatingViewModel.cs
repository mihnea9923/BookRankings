using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRankings.ViewModels
{
    public class RankingUserRatingViewModel
    {
        public Ranking Ranking { get; set; }
        public string MyRating { get; set; }
    }
}
