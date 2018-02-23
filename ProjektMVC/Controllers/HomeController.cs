using ProjektMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var books = db.Books.ToList();
            books.Sort((x, y) => y.addDate.CompareTo(x.addDate));
            ViewBag.latestBooks = books.Take(5).ToList();

            var messages = db.Messages.ToList();
            messages.Sort((x, y) => y.addDate.CompareTo(x.addDate));
            ViewBag.latestMessages = messages.Take(6).ToList();

            return View();
        }
        
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}