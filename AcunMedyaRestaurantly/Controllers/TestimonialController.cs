using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Testimonial

        public ActionResult Index()
        {
            var value = Db.Testimonials.ToList();
            return View(value);
        }
        public ActionResult TestimonialList()
        {
            var value = Db.Testimonials.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult TestimonialCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestimonialCreate(Testimonial model)
        {
            Db.Testimonials.Add(model);
            Db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult TestimonialEdit(int id)
        {
            var value = Db.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult TestimonialEdit(Testimonial model)
        {
            var values = Db.Testimonials.Find(model.TestimonialId);
            values.Name = model.Name;
            values.Title = model.Title;
            values.Description = model.Description;
            values.ImageUrl = model.ImageUrl;
            Db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public ActionResult TestimonialDelete(int id)
        {
            var values = Db.Testimonials.Find(id);
            Db.Testimonials.Remove(values);
            Db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}