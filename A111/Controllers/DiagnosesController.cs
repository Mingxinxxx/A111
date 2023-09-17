using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A111.Models;

namespace A111.Controllers
{
    public class DiagnosesController : Controller
    {
        private BookingEntities db = new BookingEntities();

        // GET: Diagnoses
        public ActionResult Index()
        {
            return View(db.DiagnoseSet.ToList());
        }

        // GET: Diagnoses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnose diagnose = db.DiagnoseSet.Find(id);
            if (diagnose == null)
            {
                return HttpNotFound();
            }
            return View(diagnose);
        }

        // GET: Diagnoses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diagnoses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Feedback")] Diagnose diagnose)
        {
            if (ModelState.IsValid)
            {
                db.DiagnoseSet.Add(diagnose);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diagnose);
        }

        // GET: Diagnoses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnose diagnose = db.DiagnoseSet.Find(id);
            if (diagnose == null)
            {
                return HttpNotFound();
            }
            return View(diagnose);
        }

        // POST: Diagnoses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Feedback")] Diagnose diagnose)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnose).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diagnose);
        }

        // GET: Diagnoses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnose diagnose = db.DiagnoseSet.Find(id);
            if (diagnose == null)
            {
                return HttpNotFound();
            }
            return View(diagnose);
        }

        // POST: Diagnoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diagnose diagnose = db.DiagnoseSet.Find(id);
            db.DiagnoseSet.Remove(diagnose);
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
