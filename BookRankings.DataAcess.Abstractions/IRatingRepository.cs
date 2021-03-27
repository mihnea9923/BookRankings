using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.DataAcess.Abstractions
{
    public interface IRatingRepository : IRepository<Rating>
    {
    }
}
