using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektMVC.Models;

namespace Biblioteka.Controllers
{
    [Authorize(Roles = "Admin,Librarian")]
    public class PenaltiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Penalties
        public ActionResult Index()
        {
            var penalties = db.Penalties.Include(p => p.Book).Include(p => p.Reader);
            return View(penalties.ToList());
        }

        // GET: Penalties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penalty penalty = db.Penalties.Find(id);
            if (penalty == null)
            {
                return HttpNotFound();
            }
            return View(penalty);
        }

        // GET: Penalties/Create
        public ActionResult Create()
        {
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title");
            ViewBag.readerID = new SelectList(db.Readers, "readerID", "login");
            return View();
        }

        // POST: Penalties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "penaltyID,readerID,bookID,fine,isPayed")] Penalty penalty)
        {
            if (ModelState.IsValid)
            {
                db.Penalties.Add(penalty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", penalty.bookID);
            ViewBag.readerID = new SelectList(db.Readers, "readerID", "login", penalty.readerID);
            return View(penalty);
        }

        // GET: Penalties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penalty penalty = db.Penalties.Find(id);
            if (penalty == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", penalty.bookID);
            ViewBag.readerID = new SelectList(db.Readers, "readerID", "login", penalty.readerID);
            return View(penalty);
        }

        // POST: Penalties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "penaltyID,readerID,bookID,fine,isPayed")] Penalty penalty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(penalty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", penalty.bookID);
            ViewBag.readerID = new SelectList(db.Readers, "readerID", "login", penalty.readerID);
            return View(penalty);
        }

        // GET: Penalties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penalty penalty = db.Penalties.Find(id);
            if (penalty == null)
            {
                return HttpNotFound();
            }
            return View(penalty);
        }

        // POST: Penalties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Penalty penalty = db.Penalties.Find(id);
            db.Penalties.Remove(penalty);
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
