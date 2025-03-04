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
    public class GaleryController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Galery

        public ActionResult Index()
        {
            var value = Db.Galeries.ToList();
            return View(value);
        }
        public ActionResult GaleryList()
        {
            var value = Db.Galeries.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult GaleryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GaleryCreate(Galery model)
        {
            Db.Galeries.Add(model);
            Db.SaveChanges();
            return RedirectToAction("GaleryList");
        }
        [HttpGet]
        public ActionResult GaleryEdit(int id)
        {
            var value = Db.Galeries.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult GaleryEdit(Galery model)
        {
            var values = Db.Galeries.Find(model.GaleryId);
            values.ImageUrl = model.ImageUrl;
            Db.SaveChanges();
            return RedirectToAction("GaleryList");
        }
        public ActionResult GaleryDelete(int id)
        {
            var values = Db.Galeries.Find(id);
            Db.Galeries.Remove(values);
            Db.SaveChanges();
            return RedirectToAction("GaleryList");
        }
    }
}