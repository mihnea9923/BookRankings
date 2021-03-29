using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.Model
{
    public class UserLike
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
