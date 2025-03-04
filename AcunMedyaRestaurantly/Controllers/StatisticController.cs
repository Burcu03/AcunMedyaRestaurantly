using AcunMedyaRestaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        RestaurantlyContext Db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var productcount = Db.Products.ToList().Count();
            var testimonialcount = Db.Testimonials.ToList().Count();
            var event1count = Db.Event1s.ToList().Count();
            var servicecount = Db.Services.ToList().Count();
            var categorycount = Db.Categories.Count();

            var chefcount = Db.Chefs.ToList().Count();
            var contactcount = Db.Contacts.ToList().Count();
            var gallerycount = Db.Galeries.ToList().Count();
            var reservationcount = Db.Reservations.ToList().Count();
            var specialcount = Db.Specials.ToList().Count();

            var categoryname = Db.Products.GroupBy(p => p.CategoryId).OrderByDescending(g => g.Count())
            .Select(g => Db.Categories.Where(c => c.CategoryId == g.Key).Select(c => c.CategoryName).FirstOrDefault()).FirstOrDefault();

            var mostExpensiveProductName = Db.Products .OrderByDescending(p => p.Price)
            .Select(p => p.Name).FirstOrDefault();

            var anaYemekCount = Db.Products.Count(p => p.CategoryId == Db.Categories
           .Where(c => c.CategoryName == "Ana Yemekler").Select(c => c.CategoryId).FirstOrDefault());
            var baslangicCount = Db.Products.Count(p => p.CategoryId == Db.Categories
           .Where(c => c.CategoryName == "Başlangıçlar").Select(c => c.CategoryId).FirstOrDefault());
            var salataCount = Db.Products.Count(p => p.CategoryId == Db.Categories
           .Where(c => c.CategoryName == "Salatalar").Select(c => c.CategoryId).FirstOrDefault());
            var cocukMenuCount = Db.Products.Count(p => p.CategoryId == Db.Categories
           .Where(c => c.CategoryName == "Çocuk Menüsü").Select(c => c.CategoryId).FirstOrDefault());
            var veganCount = Db.Products.Count(p => p.CategoryId == Db.Categories
           .Where(c => c.CategoryName == "Vegan").Select(c => c.CategoryId).FirstOrDefault());
            var glutensizCount = Db.Products.Count(p => p.CategoryId == Db.Categories
           .Where(c => c.CategoryName == "Glutensiz").Select(c => c.CategoryId).FirstOrDefault());
            var corbaCount = Db.Products.Count(p => p.CategoryId == Db.Categories
           .Where(c => c.CategoryName == "Çorbalar").Select(c => c.CategoryId).FirstOrDefault());
            var tatlıCount = Db.Products.Count(p => p.CategoryId == Db.Categories
           .Where(c => c.CategoryName == "Tatlılar").Select(c => c.CategoryId).FirstOrDefault());

            ViewBag.ProductCount = productcount;
            ViewBag.TestimonialCount = testimonialcount;
            ViewBag.Event1Count = event1count;
            ViewBag.ServiceCount = servicecount;
            ViewBag.CategoryCount = categorycount;

            ViewBag.ChefCount = chefcount;
            ViewBag.ContactCount = contactcount;
            ViewBag.GalleryCount = gallerycount;
            ViewBag.ReservationCount = reservationcount;
            ViewBag.SpecialCount = specialcount;
            ViewBag.CategoryName = categoryname;
            ViewBag.MostExpensiveProductName = mostExpensiveProductName;

            ViewBag.AnaYemekCount = anaYemekCount;
            ViewBag.BaslangicCount = baslangicCount;
            ViewBag.SalataCount = salataCount;
            ViewBag.CocukMenuCount = cocukMenuCount;
            ViewBag.VeganCount = veganCount;
            ViewBag.GlutensizCount = glutensizCount;
            ViewBag.CorbaCount = corbaCount;
            ViewBag.TatlıCount = tatlıCount;

            return View();
        }
    }
}