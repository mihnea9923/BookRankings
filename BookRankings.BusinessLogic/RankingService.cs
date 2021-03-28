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
    }
}
