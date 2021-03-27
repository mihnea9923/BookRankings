using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.DataAccess
{
    public class EFRatingRepository : EFRepository<Rating>, IRatingRepository
    {
        private readonly BooksDbContext context;

        public EFRatingRepository(BooksDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
