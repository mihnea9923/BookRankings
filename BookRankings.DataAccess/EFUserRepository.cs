using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.DataAccess
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        private readonly BooksDbContext context;

        public EFUserRepository(BooksDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
