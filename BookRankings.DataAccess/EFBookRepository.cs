using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.DataAccess
{
    public class EFBookRepository : EFRepository<Book>, IBookRepository
    {
        private readonly BooksDbContext context;

        public EFBookRepository(BooksDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
