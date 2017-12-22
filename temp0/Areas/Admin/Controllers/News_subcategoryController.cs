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
    public class News_subcategoryController : Controller
    {
        private dbasesEntities db = new dbasesEntities();

        // GET: Admin/News_subcategory
        public ActionResult Index()
        {
            var news_subcategory = db.News_subcategory.Include(n => n.News_category);
            return View(news_subcategory.ToList());
        }

        // GET: Admin/News_subcategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_subcategory news_subcategory = db.News_subcategory.Find(id);
            if (news_subcategory == null)
            {
                return HttpNotFound();
            }
            return View(news_subcategory);
        }

        // GET: Admin/News_subcategory/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.News_category, "id", "category_name");
            return View();
        }

        // POST: Admin/News_subcategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,subcategory_name,category_id")] News_subcategory news_subcategory)
        {
            if (ModelState.IsValid)
            {
                db.News_subcategory.Add(news_subcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.News_category, "id", "category_name", news_subcategory.category_id);
            return View(news_subcategory);
        }

        // GET: Admin/News_subcategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_subcategory news_subcategory = db.News_subcategory.Find(id);
            if (news_subcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.News_category, "id", "category_name", news_subcategory.category_id);
            return View(news_subcategory);
        }

        // POST: Admin/News_subcategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,subcategory_name,category_id")] News_subcategory news_subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news_subcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.News_category, "id", "category_name", news_subcategory.category_id);
            return View(news_subcategory);
        }

        // GET: Admin/News_subcategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_subcategory news_subcategory = db.News_subcategory.Find(id);
            if (news_subcategory == null)
            {
                return HttpNotFound();
            }
            return View(news_subcategory);
        }

        // POST: Admin/News_subcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News_subcategory news_subcategory = db.News_subcategory.Find(id);
            db.News_subcategory.Remove(news_subcategory);
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
