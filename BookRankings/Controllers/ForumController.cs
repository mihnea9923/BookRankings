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

        public IActionResult AddCommentToPost(Guid postId , Comment comment)
        {
            var identityUser = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var user = userService.GetByIdentityUserId(identityUser.Id);
            comment.AddedDate = DateTime.Now;
            comment.DepthLevel = 1;
            comment.User = user;
            var post = postService.Get(postId);
            post.Comments.Add(comment);
            post.CommentsNr++;
            postService.Update(post);
            return RedirectToAction("Index");
        }

        public IActionResult PostComments(Guid postId)
        {
            var post = postService.Get(postId);
            return View(post);
        }

        public IActionResult AddCommentToComment(Guid commentId ,Guid postId, Comment comment)
        {
            comment.ParentId = commentId;
            comment.AddedDate = DateTime.Now;
            var identityUser = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var user = userService.GetByIdentityUserId(identityUser.Id);
            comment.User = user;
            var parentComment = commentService.Get(commentId);
            comment.DepthLevel = parentComment.DepthLevel + 1;
            parentComment.Add(comment);
            commentService.Update(parentComment);
            var post = postService.Get(postId);
            post.CommentsNr++;
            postService.Update(post);
            return RedirectToAction("PostComments",new {postId = postId});
        }
        public List<SubcommentViewModel> GetPostSubcomments(Guid postId)
        {
            var post = postService.Get(postId);
            var model = commentService.Dfs(post.Comments);
            List<SubcommentViewModel> subcomments = new List<SubcommentViewModel>();
            for (int i = 0; i < model.Length; i++)
            {
                subcomments.Add(new SubcommentViewModel()
                {
                    AddedDate = model[i].AddedDate.ToShortDateString(),
                    Content = model[i].Content,
                    Id = model[i].Id,
                    ParentId = model[i].ParentId,
                    UserName = model[i].User.Name,
                    DepthLevel = model[i].DepthLevel

                });
            }
            subcomments = subcomments.OrderBy(o => o.DepthLevel).ToList();
            return subcomments;
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
