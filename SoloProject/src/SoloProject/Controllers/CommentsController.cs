using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SoloProject.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;

namespace SoloProject.Controllers
{
    public class CommentsController : Controller
    {
        private PostDbContext db = new PostDbContext();
        public IActionResult Index()
        {
            return View(db.Comments.Include(comments => comments.Post).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisComment = db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }
        public ActionResult Create()
        {
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "Content");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var thisComment = db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "Content");
            return View(thisComment);
        }
        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisComment = db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisComment = db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            db.Comments.Remove(thisComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
