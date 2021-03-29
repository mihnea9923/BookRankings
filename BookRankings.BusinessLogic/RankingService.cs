using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRankings.BusinessLogic
{
    public class RankingService : Service<Ranking>
    {
        private readonly IRankingRepository rankingRepository;

        public RankingService(IRankingRepository rankingRepository) : base(rankingRepository)
        {
            this.rankingRepository = rankingRepository;
        }

        public void AddByBook(Rating rating)
        {
            Ranking ranking = rankingRepository.GetByBook(rating.Book);
            if (ranking == null)
                ranking = new Ranking() { Book = rating.Book, Rating = rating.Grade, Votes = 1 };
            else
            {
                ranking.Votes++;
                ranking.Rating += rating.Grade;
            }
            rankingRepository.Update(ranking);
        }

       
    }
}
