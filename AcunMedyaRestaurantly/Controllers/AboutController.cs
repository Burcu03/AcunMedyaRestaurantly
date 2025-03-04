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
    public class AboutController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: About

        public ActionResult Index()
        {
            var value = Db.Abouts.ToList();
            return View(value);
        }
        public ActionResult AboutList()
        {
            var value = Db.Abouts.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AboutCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AboutCreate(About model)
        {
            Db.Abouts.Add(model);
            Db.SaveChanges();
            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public ActionResult AboutEdit(int id)
        {
            var value = Db.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AboutEdit(About model)
        {
            var values = Db.Abouts.Find(model.AboutId);
            values.Title = model.Title;
            values.Description = model.Description;
            values.ImageUrl = model.ImageUrl;
            Db.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult AboutDelete(int id)
        {
            var values = Db.Abouts.Find(id);
            Db.Abouts.Remove(values);
            Db.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}