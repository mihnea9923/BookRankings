using System;
using System.Collections.Generic;
using System.Text;
using BookRankings.Model;
namespace BookRankings.DataAcess.Abstractions
{
    public interface IBookRepository : IRepository<Book>
    { 
    }
}
