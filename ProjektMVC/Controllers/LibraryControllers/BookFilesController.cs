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
    public class BookFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookFiles
        public ActionResult Index()
        {
            var bookFiles = db.BookFiles.Include(b => b.Book).Include(b => b.Tag);
            return View(bookFiles.ToList());
        }

        // GET: BookFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookFile bookFile = db.BookFiles.Find(id);
            if (bookFile == null)
            {
                return HttpNotFound();
            }
            return View(bookFile);
        }

        // GET: BookFiles/Create
        public ActionResult Create()
        {
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title");
            ViewBag.fileID = new SelectList(db.Files, "fileID", "filename");
            return View();
        }

        // POST: BookFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookFileID,bookID,fileID")] BookFile bookFile)
        {
            if (ModelState.IsValid)
            {
                db.BookFiles.Add(bookFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", bookFile.bookID);
            ViewBag.fileID = new SelectList(db.Files, "fileID", "filename", bookFile.fileID);
            return View(bookFile);
        }

        // GET: BookFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookFile bookFile = db.BookFiles.Find(id);
            if (bookFile == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", bookFile.bookID);
            ViewBag.fileID = new SelectList(db.Files, "fileID", "filename", bookFile.fileID);
            return View(bookFile);
        }

        // POST: BookFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookFileID,bookID,fileID")] BookFile bookFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookID = new SelectList(db.Books, "bookID", "title", bookFile.bookID);
            ViewBag.fileID = new SelectList(db.Files, "fileID", "filename", bookFile.fileID);
            return View(bookFile);
        }

        // GET: BookFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookFile bookFile = db.BookFiles.Find(id);
            if (bookFile == null)
            {
                return HttpNotFound();
            }
            return View(bookFile);
        }

        // POST: BookFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookFile bookFile = db.BookFiles.Find(id);
            db.BookFiles.Remove(bookFile);
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
