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
    public class ChefController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Chef

        public ActionResult Index()
        {
            var value = Db.Chefs.ToList();
            return View(value);
        }
        public ActionResult ChefList()
        {
            var value = Db.Chefs.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ChefCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChefCreate(Chef model)
        {
            Db.Chefs.Add(model);
            Db.SaveChanges();
            return RedirectToAction("ChefList");
        }
        [HttpGet]
        public ActionResult ChefEdit(int id)
        {
            var value = Db.Chefs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ChefEdit(Chef model)
        {
            var values = Db.Chefs.Find(model.ChefId);
            values.Name = model.Name;
            values.Title = model.Title;
            values.ImageUrl = model.ImageUrl;
            Db.SaveChanges();
            return RedirectToAction("ChefList");
        }
        public ActionResult ChefDelete(int id)
        {
            var values = Db.Chefs.Find(id);
            Db.Chefs.Remove(values);
            Db.SaveChanges();
            return RedirectToAction("ChefList");
        }
    }
}