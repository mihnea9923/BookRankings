using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookRankings.DataAccess
{
    public class EFRankingRepository : EFRepository<Ranking>, IRankingRepository
    {
        private readonly BooksDbContext context;

        public EFRankingRepository(BooksDbContext context) : base(context)
        {
            this.context = context;
        }

        public Ranking GetByBook(Book book)
        {
            return context.Rankings.FirstOrDefault(o => o.Book == book);
        }
    }
}
