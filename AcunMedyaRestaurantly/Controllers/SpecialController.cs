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
    public class SpecialController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Special

        public ActionResult Index()
        {
            var value = Db.Specials.ToList();
            return View(value);
        }
        public ActionResult SpecialList()
        {
            var value = Db.Specials.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult SpecialCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SpecialCreate(Special model)
        {
            Db.Specials.Add(model);
            Db.SaveChanges();
            return RedirectToAction("SpecialList");
        }
        [HttpGet]
        public ActionResult SpecialEdit(int id)
        {
            var value = Db.Specials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult SpecialEdit(Special model)
        {
            var values = Db.Specials.Find(model.SpecialId);
            values.Title = model.Title;
            values.ShortDescription = model.ShortDescription;
            values.FullDescription = model.FullDescription;
            values.ImageUrl = model.ImageUrl;
            Db.SaveChanges();
            return RedirectToAction("SpecialList");
        }
        public ActionResult SpecialDelete(int id)
        {
            var values = Db.Specials.Find(id);
            Db.Specials.Remove(values);
            Db.SaveChanges();
            return RedirectToAction("SpecialList");
        }
    }
}