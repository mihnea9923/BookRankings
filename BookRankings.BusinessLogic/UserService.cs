using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.BusinessLogic
{
    public class UserService : Service<User>
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }
        public User GetByIdentityUserId(string id)
        {
            return userRepository.GetByIdentityUserId(id);
        }

        public void AddRating(User user, Rating rating)
        {
            user.Ratings.Add(rating);
            userRepository.SaveChanges();
        }
    }
}
