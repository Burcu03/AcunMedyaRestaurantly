using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    public class DefaultController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialTop()
        {
            ViewBag.Call = Db.Adresses.Select(x => x.Call).FirstOrDefault();
            ViewBag.OpenHours = Db.Adresses.Select(x => x.OpenHours).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.Subtitle = Db.Features.Select(x => x.Subtitle).FirstOrDefault();
            ViewBag.Title = Db.Features.Select(x => x.Title).FirstOrDefault();
            ViewBag.VideoUrl = Db.Features.Select(x => x.VideoUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.Title = Db.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.Description = Db.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.ImageUrl = Db.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialService()
        {
            var value = Db.Services.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialMenu()
        {
            var value = Db.Products.ToList();
            return PartialView(value);
        }
        //[HttpGet]
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ContactAdd(Contact model)
        {
            model.SendDate = DateTime.Now;
            model.IsRead = false;
            Db.Contacts.Add(model);
            Db.SaveChanges();
            ViewBag.Message = "Mesaj Başarılı";
            return View("Index");
        }
        public PartialViewResult PartialAdress()
        {
            ViewBag.Location = Db.Adresses.Select(x => x.Location).FirstOrDefault();
            ViewBag.OpenHours = Db.Adresses.Select(x => x.OpenHours).FirstOrDefault();
            ViewBag.Email = Db.Adresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.Call = Db.Adresses.Select(x => x.Call).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialSpecial()
        {
            var value = Db.Specials.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialTestimonial()
        {
            var value = Db.Testimonials.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialChef()
        {
            var value = Db.Chefs.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialBookaTable()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult BookaTableAdd(Reservation model)
        {
            model.ReservationDate = DateTime.Now;
            model.GuestCount = 1;
            //model.ReservationStatus = ;
            Db.Reservations.Add(model);
            Db.SaveChanges();
            ViewBag.Message = "Rezervasyon Başarılı";
            return RedirectToAction("Index");
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialEvent1()
        {
            var value = Db.Event1s.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialGalery()
        {
            var value = Db.Galeries.ToList();
            return PartialView(value);
        }
    }
}