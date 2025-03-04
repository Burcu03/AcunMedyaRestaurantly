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
    public class AdressController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Adress

        public ActionResult Index()
        {
            var value = Db.Adresses.ToList();
            return View(value);
        }
        public ActionResult AdressList()
        {
            var value = Db.Adresses.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AdressCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdressCreate(Adress model)
        {
            Db.Adresses.Add(model);
            Db.SaveChanges();
            return RedirectToAction("AdressList");
        }
        [HttpGet]
        public ActionResult AdressEdit(int id)
        {
            var value = Db.Adresses.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AdressEdit(Adress model)
        {
            var values = Db.Adresses.Find(model.AdressId);
            values.Location = model.Location;
            values.OpenHours = model.OpenHours;
            values.Email = model.Email;
            values.Call = model.Call;
            Db.SaveChanges();
            return RedirectToAction("AdressList");
        }
        public ActionResult AdressDelete(int id)
        {
            var values = Db.Adresses.Find(id);
            Db.Adresses.Remove(values);
            Db.SaveChanges();
            return RedirectToAction("AdressList");
        }
    }
}