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
    public class News_categoryController : Controller
    {
        private dbasesEntities db = new dbasesEntities();

        // GET: Admin/News_category
        public ActionResult Index()
        {
            return View(db.News_category.ToList());
        }

        // GET: Admin/News_category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_category news_category = db.News_category.Find(id);
            if (news_category == null)
            {
                return HttpNotFound();
            }
            return View(news_category);
        }

        // GET: Admin/News_category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News_category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,category_name")] News_category news_category)
        {
            if (ModelState.IsValid)
            {
                db.News_category.Add(news_category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news_category);
        }

        // GET: Admin/News_category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_category news_category = db.News_category.Find(id);
            if (news_category == null)
            {
                return HttpNotFound();
            }
            return View(news_category);
        }

        // POST: Admin/News_category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,category_name")] News_category news_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news_category);
        }

        // GET: Admin/News_category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_category news_category = db.News_category.Find(id);
            if (news_category == null)
            {
                return HttpNotFound();
            }
            return View(news_category);
        }

        // POST: Admin/News_category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News_category news_category = db.News_category.Find(id);
            db.News_category.Remove(news_category);
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
