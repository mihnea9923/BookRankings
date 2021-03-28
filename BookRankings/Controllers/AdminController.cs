using BookRankings.BusinessLogic;
using BookRankings.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookRankings.Controllers
{

    //[Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly BookService bookService;
        private readonly UserService userService;
        private readonly UserManager<IdentityUser> userManager;

        public AdminController(BookService bookService , UserService userService ,
            UserManager<IdentityUser> userManager)
        {
            this.bookService = bookService;
            this.userService = userService;
            this.userManager = userManager;
        }
        
        public IActionResult Index()
        {
            var books = bookService.GetAll();
            return View(books);
        }
        [HttpPost]
        public IActionResult Add(Book book , List<int> nr)
        {
            var identityUser = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var user = userService.GetByIdentityUserId(identityUser.Id);
            book.Published = DateTime.Now;
            book.AddedBy = user;
            bookService.Add(book);
            if(Request.Form.Files != null)
            {
                bookService.AddBookPhoto(Request.Form.Files[0] , book.ISBN );
            }
            return RedirectToAction("Index");
        }
        public IActionResult Search(string keyword)
        {
            keyword = keyword.ToLower();
            Expression<Func<Book, bool>> filter = x => x.Author.ToLower().Contains(keyword) ||
                                                       x.Name.ToLower().Contains(keyword) ||
                                                       x.AddedBy.Name.ToLower().Contains(keyword);
            var books = bookService.GetAll(filter, null, null);
            return PartialView("_BookTable", books);
        }
    }
}
