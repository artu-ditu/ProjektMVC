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
    public class BookTagsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookTags
        public ActionResult Index()
        {
            var bookTags = db.BookTags.Include(b => b.Book).Include(b => b.Tag);
            return View(bookTags.ToList());
        }

        // GET: BookTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTag bookTag = db.BookTags.Find(id);
            if (bookTag == null)
            {
                return HttpNotFound();
            }
            return View(bookTag);
        }

        // GET: BookTags/Create
        public ActionResult Create()
        {
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title");
            ViewBag.tagID = new SelectList(db.Tags, "tagID", "value");
            return View();
        }

        // POST: BookTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookTagID,bookID,tagID")] BookTag bookTag)
        {
            if (ModelState.IsValid)
            {
                db.BookTags.Add(bookTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", bookTag.bookID);
            ViewBag.tagID = new SelectList(db.Tags, "tagID", "value", bookTag.tagID);
            return View(bookTag);
        }

        // GET: BookTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTag bookTag = db.BookTags.Find(id);
            if (bookTag == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", bookTag.bookID);
            ViewBag.tagID = new SelectList(db.Tags, "tagID", "value", bookTag.tagID);
            return View(bookTag);
        }

        // POST: BookTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookTagID,bookID,tagID")] BookTag bookTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", bookTag.bookID);
            ViewBag.tagID = new SelectList(db.Tags, "tagID", "value", bookTag.tagID);
            return View(bookTag);
        }

        // GET: BookTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTag bookTag = db.BookTags.Find(id);
            if (bookTag == null)
            {
                return HttpNotFound();
            }
            return View(bookTag);
        }

        // POST: BookTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookTag bookTag = db.BookTags.Find(id);
            db.BookTags.Remove(bookTag);
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
