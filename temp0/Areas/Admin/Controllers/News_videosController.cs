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
    public class News_videosController : Controller
    {
        private dbasesEntities db = new dbasesEntities();

        // GET: Admin/News_videos
        public ActionResult Index()
        {
            return View(db.News_videos.ToList());
        }

        // GET: Admin/News_videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_videos news_videos = db.News_videos.Find(id);
            if (news_videos == null)
            {
                return HttpNotFound();
            }
            return View(news_videos);
        }

        // GET: Admin/News_videos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News_videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,video_path,video_name,video_volume")] News_videos news_videos)
        {
            if (ModelState.IsValid)
            {
                db.News_videos.Add(news_videos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news_videos);
        }

        // GET: Admin/News_videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_videos news_videos = db.News_videos.Find(id);
            if (news_videos == null)
            {
                return HttpNotFound();
            }
            return View(news_videos);
        }

        // POST: Admin/News_videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,video_path,video_name,video_volume")] News_videos news_videos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news_videos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news_videos);
        }

        // GET: Admin/News_videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_videos news_videos = db.News_videos.Find(id);
            if (news_videos == null)
            {
                return HttpNotFound();
            }
            return View(news_videos);
        }

        // POST: Admin/News_videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News_videos news_videos = db.News_videos.Find(id);
            db.News_videos.Remove(news_videos);
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
