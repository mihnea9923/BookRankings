using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public List<Rating> Search(string keyword , List<Rating> ratings)
        {
            if (keyword != null)
                keyword = keyword.ToLower();
            Expression<Func<Rating, bool>> filter = null;
            if (keyword != "" && keyword != null)
                filter = x => x.Book.Name.ToLower().Contains(keyword) ||
                               x.Book.Author.ToLower().Contains(keyword);
            if (filter != null)
                ratings = ratings.AsQueryable().Where(filter).ToList();
            return ratings;
        }

        public string GetGradeByBook(Book book)
        {
            var ratings = ratingRepository.GetAll();
            var myRating = ratings.FirstOrDefault(o => o.Book == book);
            if (myRating == null)
                return "-";
            return myRating.Grade.ToString();
        }
    }
}
