using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.DataAccess
{
    public class EFPostRepository : EFRepository<Post>, IPostRepository
    {
        private readonly BooksDbContext context;

        public EFPostRepository(BooksDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
