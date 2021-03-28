using System;

namespace BookRankings.Model
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Published { get; set; }
        public virtual User AddedBy { get; set; }
    }
}
