using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.DataAcess.Abstractions
{
    public interface IRankingRepository : IRepository<Ranking>
    {
        Ranking GetByBook(Book book);
    }
}
