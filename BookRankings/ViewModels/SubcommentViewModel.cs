using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRankings.ViewModels
{
    public class SubcommentViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string AddedDate { get; set; }
        public string  UserName { get; set; }
        public Guid? ParentId { get; set; }
        public int DepthLevel { get; internal set; }
    }
}
