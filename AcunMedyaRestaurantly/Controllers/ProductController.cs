using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{        [Authorize]
    public class ProductController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Product


        public ActionResult ProductList( string searchText)
        {
            List<Product> values;
            if(searchText != null)
            {
                values = Db.Products.Where(x => x.Name.Contains(searchText)).ToList();
                return View(values);
            }
            var value = Db.Products.ToList();
            //ViewBag.UserName = Session["a"];
            return View(value);
        }
        [HttpGet]
        public ActionResult ProductCreate()
        {
            List<SelectListItem> values = (from x in Db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.CategoryName,
                                               Value=x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(Product model)
        {
            Db.Products.Add(model);
            Db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            var value = Db.Products.Find(id);

            List<SelectListItem> values = (from x in Db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(value);
        }
        [HttpPost]
        public ActionResult ProductEdit(Product model)
        {
            var values = Db.Products.Find(model.ProductId);
            values.Name = model.Name;
            values.Description = model.Description;
            values.Price = model.Price;
            values.ImageUrl = model.ImageUrl;
            values.CategoryId = model.CategoryId;
            Db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductDelete(int id)
        {
            var values = Db.Products.Find(id);
            Db.Products.Remove(values);
            Db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}
