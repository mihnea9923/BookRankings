using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.DataAccess
{
    public class EFCommentRepository : EFRepository<Comment>, ICommentRepository
    {
        private readonly BooksDbContext context;

        public EFCommentRepository(BooksDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
