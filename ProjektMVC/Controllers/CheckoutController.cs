using ProjektMVC.Models;
using ProjektMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMVC.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Checkout
        public ActionResult Finalize()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Finalize(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                order.Email = User.Identity.Name;
                order.OrderDate = DateTime.Now;
                

                //Save Order
                db.Orders.Add(order);
                db.SaveChanges();
                //Process the order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);
                

                return RedirectToAction("Complete", new { id = order.OrderId });
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = db.Orders.Any(
                o => o.OrderId == id &&
                o.Email == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}