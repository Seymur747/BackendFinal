using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using temp0.Models;

namespace temp0.Areas.Admin.Controllers
{
    public class User_commentController : Controller
    {
        private dbasesEntities db = new dbasesEntities();

        // GET: Admin/User_comment
        public ActionResult Index()
        {
            var user_comment = db.User_comment.Include(u => u.News).Include(u => u.Users);
            return View(user_comment.ToList());
        }

        // GET: Admin/User_comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_comment user_comment = db.User_comment.Find(id);
            if (user_comment == null)
            {
                return HttpNotFound();
            }
            return View(user_comment);
        }

        // GET: Admin/User_comment/Create
        public ActionResult Create()
        {
            ViewBag.news_id = new SelectList(db.News, "id", "longText");
            ViewBag.users_id = new SelectList(db.Users, "id", "names");
            return View();
        }

        // POST: Admin/User_comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,texts,users_id,add_date,news_id")] User_comment user_comment)
        {
            if (ModelState.IsValid)
            {
                db.User_comment.Add(user_comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.news_id = new SelectList(db.News, "id", "longText", user_comment.news_id);
            ViewBag.users_id = new SelectList(db.Users, "id", "names", user_comment.users_id);
            return View(user_comment);
        }

        // GET: Admin/User_comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_comment user_comment = db.User_comment.Find(id);
            if (user_comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.news_id = new SelectList(db.News, "id", "longText", user_comment.news_id);
            ViewBag.users_id = new SelectList(db.Users, "id", "names", user_comment.users_id);
            return View(user_comment);
        }

        // POST: Admin/User_comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,texts,users_id,add_date,news_id")] User_comment user_comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.news_id = new SelectList(db.News, "id", "longText", user_comment.news_id);
            ViewBag.users_id = new SelectList(db.Users, "id", "names", user_comment.users_id);
            return View(user_comment);
        }

        // GET: Admin/User_comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_comment user_comment = db.User_comment.Find(id);
            if (user_comment == null)
            {
                return HttpNotFound();
            }
            return View(user_comment);
        }

        // POST: Admin/User_comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_comment user_comment = db.User_comment.Find(id);
            db.User_comment.Remove(user_comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
