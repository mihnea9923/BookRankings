using BookRankings.BusinessLogic;
using BookRankings.Model;
using BookRankings.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRankings.Controllers
{
    public class ForumController : Controller
    {
        private readonly UserService userService;
        private readonly PostService postService;
        private readonly CommentService commentService;
        private readonly UserLikeService userLikeService;
        private readonly UserManager<IdentityUser> userManager;

        public ForumController(UserService userService, PostService postService, CommentService commentService
            , UserLikeService userLikeService, UserManager<IdentityUser> userManager)
        {
            this.userService = userService;
            this.postService = postService;
            this.commentService = commentService;
            this.userLikeService = userLikeService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(CreateViewModel(postService.GetAll().ToList()));
        }
        public IActionResult Comments()
        {
            return View();
        }
        public IActionResult Add(Post post)
        {
            post.PostedDate = DateTime.Now;
            postService.Add(post);
            return RedirectToAction("Index");
        }
        public IActionResult Search(string keyword)
        {
            var posts = postService.Search(keyword);
            var model = CreateViewModel(posts);
           
            return PartialView("_Posts", model);
        }
        public IActionResult AddLike(Guid id)
        {
            var identityUser = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var user = userService.GetByIdentityUserId(identityUser.Id);
            if (userLikeService.Liked(id , user.Id) == false)
            {
                var post = postService.Get(id);
                post.Likes++;
                postService.Update(post);
                userLikeService.Add(new UserLike { Post = post, User = user });
            }
            else
            {
                var post = postService.Get(id);
                post.Likes--;
                postService.Update(post);
                userLikeService.RemoveLike(id, user.Id);
            }
            return PartialView("_Posts", CreateViewModel(postService.GetAll().ToList()));
        }


        private List<PostLikedViewModel>  CreateViewModel(List<Post> posts)
        {
            var identityUser = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var user = userService.GetByIdentityUserId(identityUser.Id);
            List<PostLikedViewModel> model = new List<PostLikedViewModel>();
            foreach (var it in posts)
            {
                bool liked = userLikeService.Liked(it.Id, user.Id);
                model.Add(new PostLikedViewModel { Liked = liked, Post = it });
            }
            return model;
        }
    }
}
