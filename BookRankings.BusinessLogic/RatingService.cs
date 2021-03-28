using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.BusinessLogic
{
    public class RatingService : Service<Rating>
    {
        private readonly IRatingRepository ratingRepository;

        public RatingService(IRatingRepository ratingRepository) : base(ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }
    }
}
