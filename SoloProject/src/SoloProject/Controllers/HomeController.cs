using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SoloProject.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SoloProject.Controllers
{
    public class HomeController : Controller
    {
        private PostDbContext db = new PostDbContext();
        public IActionResult Index()
        {
            ViewBag.Comments = 1;
            return View(db.Posts.ToList());
        }
    }
}
