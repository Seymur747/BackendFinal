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
    public class MesagesController : Controller
    {
        private dbasesEntities db = new dbasesEntities();
      
      
      
        // GET: Admin/Mesages
        public ActionResult Index()
        {
            return View(db.Mesages.ToList());
          
        }

        // GET: Admin/Mesages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesages mesages = db.Mesages.Find(id);
            if (mesages == null)
            {
                return HttpNotFound();
            }
            return View(mesages);
        }

        // GET: Admin/Mesages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Mesages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,texts,writer_name,writer_email")] Mesages mesages)
        {
            if (ModelState.IsValid)
            {
                db.Mesages.Add(mesages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mesages);
        }

        // GET: Admin/Mesages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesages mesages = db.Mesages.Find(id);
            if (mesages == null)
            {
                return HttpNotFound();
            }
            return View(mesages);
        }

        // POST: Admin/Mesages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,texts,writer_name,writer_email")] Mesages mesages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mesages);
        }

        // GET: Admin/Mesages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesages mesages = db.Mesages.Find(id);
            if (mesages == null)
            {
                return HttpNotFound();
            }
            return View(mesages);
        }

        // POST: Admin/Mesages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mesages mesages = db.Mesages.Find(id);
            db.Mesages.Remove(mesages);
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
