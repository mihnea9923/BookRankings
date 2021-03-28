using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public User GetByIdentityUserId(string id)
        {
            return context.Users.Where(o => o.UserId == id).FirstOrDefault();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
