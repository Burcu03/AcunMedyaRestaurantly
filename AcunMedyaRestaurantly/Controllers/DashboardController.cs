using AcunMedyaRestaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.Productcount = Db.Products.Count();
            ViewBag.Categorycount = Db.Categories.Count();
            ViewBag.Chefcount = Db.Chefs.Count();
            ViewBag.Specialcount = Db.Specials.Count();
            ViewBag.Testimonialcount = Db.Testimonials.Count();
            ViewBag.Servicecount = Db.Services.Count();
            ViewBag.Event1count =  Db.Event1s.Count();
            ViewBag.Contactcount = Db.Contacts.Count();
            return View();
        }
        public PartialViewResult ReservationPartial()
        {
            var  values=Db.Reservations.ToList();
            return PartialView(values);
        }
    }
}