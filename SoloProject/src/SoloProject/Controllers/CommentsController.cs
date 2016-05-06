using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SoloProject.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Authorization;
using System.Security.Claims;

namespace SoloProject.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db
        )
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index(int id)
        {
            return View(_db.Comments.Where(comments => comments.PostId == id).Include(comments => comments.Post).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }

        public IActionResult Create(int id)
        {
            ViewBag.PostId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            var id = comment.PostId;
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Posts");
        }

        public IActionResult Edit(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            ViewBag.PostId = new SelectList(_db.Posts, "PostId", "Content");
            return View(thisComment);
        }
        [HttpPost]
        public IActionResult Edit(Comment comment)
        {
            var id = comment.PostId;
            _db.Entry(comment).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index","Posts");
        }
        public IActionResult Delete(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            _db.Comments.Remove(thisComment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Posts");
        }
    }
}
