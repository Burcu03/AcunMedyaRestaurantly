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
    public class Event1Controller : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Event1

        public ActionResult Index()
        {
            var value = Db.Event1s.ToList();
            return View(value);
        }
        public ActionResult Event1List()
        {
            var value = Db.Event1s.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult Event1Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Event1Create(Event1 model)
        {
            Db.Event1s.Add(model);
            Db.SaveChanges();
            return RedirectToAction("Event1List");
        }
        [HttpGet]
        public ActionResult Event1Edit(int id)
        {
            var value = Db.Event1s.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Event1Edit(Event1 model)
        {
            var values = Db.Event1s.Find(model.Event1Id);
            values.Title = model.Title;
            values.Price = model.Price;
            values.Description = model.Description;
            values.ImageUrl = model.ImageUrl;
            Db.SaveChanges();
            return RedirectToAction("Event1List");
        }
        public ActionResult Event1Delete(int id)
        {
            var values = Db.Event1s.Find(id);
            Db.Event1s.Remove(values);
            Db.SaveChanges();
            return RedirectToAction("Event1List");
        }
    }
}