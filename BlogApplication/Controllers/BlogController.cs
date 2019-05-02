using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogApplication.Database.Repositories;

namespace BlogApplication.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogRepository _blogRepository = new BlogRepository();

        public async Task<ActionResult> Recent()
        {
            var blogs = await _blogRepository.GetRecentPosts();
            return View(blogs);
        }
    }
}