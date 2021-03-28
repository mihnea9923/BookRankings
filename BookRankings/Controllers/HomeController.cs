using BookRankings.BusinessLogic;
using BookRankings.Model;
using BookRankings.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookRankings.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookService bookService;
        private readonly UserService userService;
        private readonly RatingService ratingService;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(BookService bookService ,UserService userService , RatingService ratingService ,
            UserManager<IdentityUser> userManager)
        {
            this.bookService = bookService;
            this.userService = userService;
            this.ratingService = ratingService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var identityUser = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var user = userService.GetByIdentityUserId(identityUser.Id);
            return View(user.Ratings);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Add(Rating rating , string author , string name)
        {
            var identityUser = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            Book book = bookService.Get(author, name);
            rating.Book = book;
            rating.AddedDate = DateTime.Now;
            var user = userService.GetByIdentityUserId(identityUser.Id);
            ratingService.Add(rating);
            userService.AddRating(user, rating);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(Guid id)
        {
            ratingService.Remove(id);
            return RedirectToAction("Index");
        }
        public IActionResult GetRatings()
        {
            var identityUser = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var user = userService.GetByIdentityUserId(identityUser.Id);
            return PartialView("_Ratings", user.Ratings);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
