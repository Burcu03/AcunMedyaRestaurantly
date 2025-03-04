using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System.Linq;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();

        // GET: Reservation
        public ActionResult Index()
        {
            var value = Db.Reservations.ToList();
            return View(value);
        }

        public ActionResult ReservationList()
        {
            var value = Db.Reservations.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult ReservationCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReservationCreate(Reservation model)
        {
            Db.Reservations.Add(model);
            Db.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public ActionResult ReservationEdit(int id)
        {
            var value = Db.Reservations.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult ReservationEdit(Reservation model)
        {
            var values = Db.Reservations.Find(model.ReservationId);
            values.Name = model.Name;
            values.Email = model.Email;
            values.Phone = model.Phone;
            values.Description = model.Description;
            values.ReservationDate = model.ReservationDate;
            values.Time = model.Time;
            values.GuestCount = model.GuestCount;
            values.ReservationStatus = model.ReservationStatus;
            Db.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        public ActionResult ReservationDelete(int id)
        {
            var values = Db.Reservations.Find(id);
            Db.Reservations.Remove(values);
            Db.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        [HttpPost]
        public JsonResult UpdateReservationStatus(int id, string status)
        {
            var reservation = Db.Reservations.Find(id);
            if (reservation != null)
            {
                reservation.ReservationStatus = status;
                Db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
