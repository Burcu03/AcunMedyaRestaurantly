using AcunMedyaRestaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    public class AdminLayoutController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            ViewBag.notificationIsreadByfalseCount=Db.Notifications.Where(x=>x.IsRead=="False").Count();
            var values = Db.Notifications.Where(x=> x.IsRead=="False").ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public ActionResult NotificationStatusChangeToTrue(int id)
        {
            var value=Db.Notifications.Find(id);
            value.IsRead = "True";
            Db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }
        public PartialViewResult PartialContact()
        {
            ViewBag.messageIsreadByfalseCount = Db.Contacts.Where(x => x.IsRead == false).Count();
            var values = Db.Contacts.Where(x => x.IsRead == false).ToList();
            return PartialView(values);
        }
        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var message = Db.Contacts.Find(id);
            message.IsRead = true;
            Db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }
    }
}