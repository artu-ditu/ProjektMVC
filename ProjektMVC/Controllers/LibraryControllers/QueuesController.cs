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
    public class QueuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Queues
        public ActionResult Index()
        {
            var queues = db.Queues.Include(q => q.Book).Include(q => q.Reader);
            return View(queues.ToList());
        }

        // GET: Queues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = db.Queues.Find(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            return View(queue);
        }

        // GET: Queues/Create
        public ActionResult Create()
        {
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title");
            ViewBag.readerID = new SelectList(db.Readers, "readerID", "login");
            return View();
        }

        // POST: Queues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "queueID,bookID,readerID,addDate")] Queue queue)
        {
            if (ModelState.IsValid)
            {
                db.Queues.Add(queue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", queue.bookID);
            ViewBag.readerID = new SelectList(db.Readers, "readerID", "login", queue.readerID);
            return View(queue);
        }

        // GET: Queues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = db.Queues.Find(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", queue.bookID);
            ViewBag.readerID = new SelectList(db.Readers, "readerID", "login", queue.readerID);
            return View(queue);
        }

        // POST: Queues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "queueID,bookID,readerID,addDate")] Queue queue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(queue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", queue.bookID);
            ViewBag.readerID = new SelectList(db.Readers, "readerID", "login", queue.readerID);
            return View(queue);
        }

        // GET: Queues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = db.Queues.Find(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            return View(queue);
        }

        // POST: Queues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Queue queue = db.Queues.Find(id);
            db.Queues.Remove(queue);
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
