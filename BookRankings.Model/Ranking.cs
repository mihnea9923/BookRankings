using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.Model
{
    public class Ranking
    {
        public Guid Id { get; set; }
        public Book Book { get; set; }
        public int Votes { get; set; }
        public decimal Rating { get; set; }
    }
}
