using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SoloProject.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SoloProject.Controllers
{
    public class PostsController : Controller
    {
        private PostDbContext db = new PostDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
