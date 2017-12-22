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
    public class NewsController : Controller
    {
        private dbasesEntities db = new dbasesEntities();

        // GET: Admin/News
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.Users).Include(n => n.News_category).Include(n => n.News_images).Include(n => n.News_videos);
            return View(news.ToList());
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            ViewBag.users_id = new SelectList(db.Users, "id", "names");
            ViewBag.category_id = new SelectList(db.News_category, "id", "category_name");
            ViewBag.image_id = new SelectList(db.News_images, "id", "image_path");
            ViewBag.video_id = new SelectList(db.News_videos, "id", "video_path");
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,longText,shortText,add_date,users_id,category_id,image_id,video_id")] News news)
        {
            if (ModelState.IsValid)
            {

                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.users_id = new SelectList(db.Users, "id", "names", news.users_id);
            ViewBag.category_id = new SelectList(db.News_category, "id", "category_name", news.category_id);
            ViewBag.image_id = new SelectList(db.News_images, "id", "image_path", news.image_id);
            ViewBag.video_id = new SelectList(db.News_videos, "id", "video_path", news.video_id);

         
            return View(news);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.users_id = new SelectList(db.Users, "id", "names", news.users_id);
            ViewBag.category_id = new SelectList(db.News_category, "id", "category_name", news.category_id);
            ViewBag.image_id = new SelectList(db.News_images, "id", "image_path", news.image_id);
            ViewBag.video_id = new SelectList(db.News_videos, "id", "video_path", news.video_id);
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,longText,shortText,add_date,users_id,category_id,image_id,video_id")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.users_id = new SelectList(db.Users, "id", "names", news.users_id);
            ViewBag.category_id = new SelectList(db.News_category, "id", "category_name", news.category_id);
            ViewBag.image_id = new SelectList(db.News_images, "id", "image_path", news.image_id);
            ViewBag.video_id = new SelectList(db.News_videos, "id", "video_path", news.video_id);
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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
