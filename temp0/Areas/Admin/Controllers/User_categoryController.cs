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
    public class User_categoryController : Controller
    {
        private dbasesEntities db = new dbasesEntities();

        // GET: Admin/User_category
        public ActionResult Index()
        {
            return View(db.User_category.ToList());
        }

        // GET: Admin/User_category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_category user_category = db.User_category.Find(id);
            if (user_category == null)
            {
                return HttpNotFound();
            }
            return View(user_category);
        }

        // GET: Admin/User_category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User_category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,category_name")] User_category user_category)
        {
            if (ModelState.IsValid)
            {
                db.User_category.Add(user_category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_category);
        }

        // GET: Admin/User_category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_category user_category = db.User_category.Find(id);
            if (user_category == null)
            {
                return HttpNotFound();
            }
            return View(user_category);
        }

        // POST: Admin/User_category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,category_name")] User_category user_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_category);
        }

        // GET: Admin/User_category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_category user_category = db.User_category.Find(id);
            if (user_category == null)
            {
                return HttpNotFound();
            }
            return View(user_category);
        }

        // POST: Admin/User_category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_category user_category = db.User_category.Find(id);
            db.User_category.Remove(user_category);
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
