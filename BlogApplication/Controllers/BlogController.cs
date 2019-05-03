using System;
using System.Collections.Generic;
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

        public async Task<ActionResult> Details(int blogId)
        {
            var blog = await _blogRepository.GetByIdAsync(blogId);
            var user = await _userRepository.GetByIdAsync(blog.UserId);
            var comments = await _commentRepository.GetAllCommentsForBlog(blogId);

            var viewModel = new BlogPostViewModel
            {
                UserFullName = $"{user.FirstName} {user.LastName}",
                Post = blog,
                Comments = comments
            };

            return View(viewModel);
        }
    }
}