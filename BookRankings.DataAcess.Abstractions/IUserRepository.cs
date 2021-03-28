using BookRankings.Model;
using System;

namespace BookRankings.DataAcess.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByIdentityUserId(string id);
        void SaveChanges();
    }
}
