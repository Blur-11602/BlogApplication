using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogApplication.Database.Repositories;
using BlogApplication.Models;

namespace BlogApplication.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogRepository _blogRepository = new BlogRepository();
        private readonly CommentRepository _commentRepository = new CommentRepository();
        private readonly UserRepository _userRepository = new UserRepository();

        public async Task<ActionResult> Recent()
        {
            var blogs = await _blogRepository.GetRecentPosts();
            return View(blogs);
        }

        [AcceptVerbs("GET")]
        public async Task<ActionResult> Details(int blogId)
        {
            var blog = await _blogRepository.GetByIdAsync(blogId);
            var user = await _userRepository.GetByIdAsync(blog.UserId);
            var comments = await _commentRepository.GetAllCommentsForBlog(blogId);

            var viewModel = new BlogPostViewModel
            {
                UserFullName = $"{user.FirstName} {user.LastName}",
                Post = blog,
                Comments = comments.OrderByDescending(x => x.PostedDate).ToList()
            };

            return View(viewModel);
        }

        [AcceptVerbs("POST")]
        public async Task<ActionResult> PostComment(Comment comment)
        {
            var users = await _userRepository.GetAllAsync();
            comment.UserId = users.First().Id;
            comment.PostedDate = DateTime.Now;
            var commentId = _commentRepository.InsertAsync(comment);
            return RedirectToAction("Details", new {blogId = comment.BlogPostId});
        }

        [AcceptVerbs("GET")]
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs("POST")]
        public async Task<ActionResult> Create(BlogPost post)
        {
            var users = await _userRepository.GetAllAsync();
            post.UserId = users.First().Id;
            post.PublishDate = DateTime.Now;
            var blogId = (int) await _blogRepository.InsertAsync(post);
            return RedirectToAction("Details", new {blogId = blogId});
        }
    }
}