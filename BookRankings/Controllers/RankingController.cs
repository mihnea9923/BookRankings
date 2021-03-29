using BookRankings.BusinessLogic;
using BookRankings.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRankings.Controllers
{
    public class RankingController : Controller
    {
        private readonly RankingService rankingService;
        private readonly RatingService ratingService;

        public RankingController(RankingService rankingService , RatingService ratingService)
        {
            this.rankingService = rankingService;
            this.ratingService = ratingService;
        }
        public IActionResult Index()
        {
            
            List<RankingUserRatingViewModel> model = ViewModelForIndex();
            return View(model);
        }


        public IActionResult Search(string keyword)
        {
            var model = ViewModelForIndex();
            if(keyword != null && keyword != "" )
            {
                keyword = keyword.ToLower();
                model.RemoveAll(iterator => iterator.Ranking.Book.Author.ToLower().Contains(keyword) == false
                        && iterator.Ranking.Book.Name.ToLower().Contains(keyword) == false);
                   
            }
            return PartialView("_RankingTable" , model);
        }
        public IActionResult Sort(int sortOption)
        {
            var model = ViewModelForIndex();
            if(sortOption == 0)
                model = model.OrderByDescending(it => it.Ranking.Rating / it.Ranking.Votes).ToList();
            else if(sortOption == 1)
                model = model.OrderByDescending(it => it.Ranking.Votes).ToList();
            else if(sortOption == 2)
                model = model.OrderByDescending(it => it.MyRating).ToList();

            return PartialView("_RankingTable", model);
        }









        private List<RankingUserRatingViewModel> ViewModelForIndex()
        {
            var rankings = rankingService.GetAll();
            List<RankingUserRatingViewModel> model = new List<RankingUserRatingViewModel>();
            foreach (var rank in rankings)
            {
                string grade = ratingService.GetGradeByBook(rank.Book);
                model.Add(new RankingUserRatingViewModel() { MyRating = grade, Ranking = rank });
            }
            return model;
        }

    }
}
