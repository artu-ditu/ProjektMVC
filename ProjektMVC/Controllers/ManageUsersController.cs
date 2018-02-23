using Microsoft.AspNet.Identity.EntityFramework;
using ProjektMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ProjektMVC.Models.ManageUsers;

namespace ProjektMVC.Controllers
{
    public class ManageUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin,Librarian")]
        public ActionResult GetUsers()
        {
            var listOfUsers = (from u in db.Users
                               let query = (from ur in db.Set<IdentityUserRole>()
                                            where ur.UserId.Equals(u.Id)
                                            join r in db.Roles on ur.RoleId equals r.Id
                                            select r.Name)
                               select new UserRoleInfo() { User = u, Roles = query.ToList<string>() })
                            .ToList();

            for (int i = listOfUsers.Count - 1; i >= 0; i--)
            {
                if (listOfUsers[i].Roles.ElementAt(0) != "User")
                    listOfUsers.RemoveAt(i);
            }

            return View(listOfUsers);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetLibrarians()
        {
            var listOfUsers = (from u in db.Users
                               let query = (from ur in db.Set<IdentityUserRole>()
                                            where ur.UserId.Equals(u.Id)
                                            join r in db.Roles on ur.RoleId equals r.Id
                                            select r.Name)
                               select new UserRoleInfo() { User = u, Roles = query.ToList<string>() })
                            .ToList();

            for (int i = listOfUsers.Count - 1; i >= 0; i--)
            {
                if (listOfUsers[i].Roles.ElementAt(0) != "Librarian")
                    listOfUsers.RemoveAt(i);
            }

            return View(listOfUsers);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetNonactive()
        {
            var listOfUsers = (from u in db.Users
                               let query = (from ur in db.Set<IdentityUserRole>()
                                            where ur.UserId.Equals(u.Id)
                                            join r in db.Roles on ur.RoleId equals r.Id
                                            select r.Name)
                               select new UserRoleInfo() { User = u, Roles = query.ToList<string>() })
                            .ToList();

            for (int i = listOfUsers.Count - 1; i >= 0; i--)
            {
                if (listOfUsers[i].User.EmailConfirmed != false)
                    listOfUsers.RemoveAt(i);
            }

            return View(listOfUsers);
        }

        [Authorize(Roles = "Admin,Librarian")]
        public ActionResult DeleteUser(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Librarian")]
        public ActionResult DeleteUserConfirmed(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.Id == id);
            Db.Users.Remove(user);
            Db.SaveChanges();
            return RedirectToAction("GetUsers");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteLibrarian(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("DeleteLibrarian")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteLibrarianConfirmed(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.Id == id);
            Db.Users.Remove(user);
            Db.SaveChanges();
            return RedirectToAction("GetLibrarians");
        }

        [Authorize(Roles = "Admin,Librarian")]
        public ActionResult DetailsUser(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsLibrarian(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}