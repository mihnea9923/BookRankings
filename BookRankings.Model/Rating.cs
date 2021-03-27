using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.Model
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Book Book { get; set; }
        public DateTime AddedDate { get; set; }
        public string Description { get; set; }
        public decimal Grade { get; set; }
    }
}
