using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogApplication.Database.Repositories;
using BlogApplication.Models;
using ServiceStack.OrmLite;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your about page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}