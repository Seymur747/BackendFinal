using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using temp0.Models;
using System.IO;

namespace temp0.Areas.Admin.Controllers
{
    public class News_imagesController : Controller
    {
        private dbasesEntities db = new dbasesEntities();

        // GET: Admin/News_images
        public ActionResult Index()
        {
            return View(db.News_images.ToList());
        }

        // GET: Admin/News_images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_images news_images = db.News_images.Find(id);
            if (news_images == null)
            {
                return HttpNotFound();
            }
            return View(news_images);
        }

        // GET: Admin/News_images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News_images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,image_path,image_name,image_volume")] News_images news_images,HttpPostedFileBase image_path)
        {
          
            if (ModelState.IsValid)
            {
                if (image_path.ContentType != "image/png" && image_path.ContentType != "image/jpeg" && image_path.ContentType != "image/gif")
                {

                    return RedirectToAction("Create");
                }

                string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + image_path.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"),filename);
                image_path.SaveAs(path);
                news_images.image_path = filename;
                db.News_images.Add(news_images);
                news_images.image_volume = image_path.ContentLength;
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(news_images);
        }

        // GET: Admin/News_images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_images news_images = db.News_images.Find(id);
            if (news_images == null)
            {
                return HttpNotFound();
            }
            return View(news_images);
        }

        // POST: Admin/News_images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,image_path,image_name,image_volume")] News_images news_images)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news_images).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news_images);
        }

        // GET: Admin/News_images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_images news_images = db.News_images.Find(id);
            if (news_images == null)
            {
                return HttpNotFound();
            }
            return View(news_images);
        }

        // POST: Admin/News_images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News_images news_images = db.News_images.Find(id);
            db.News_images.Remove(news_images);
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
