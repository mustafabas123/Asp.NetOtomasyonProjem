using OtomasyonProjesi.Models.Classlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtomasyonProjesi.Controllers
{

    public class SalesController : Controller
    {
        ProjeContext context=new ProjeContext();
        public ActionResult Index()
        {
            var values=context.SalesMovements.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSales()
        {
            List<SelectListItem> values1 = (from x in context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName, // Ekranda Gözüken değer
                                               Value = x.ProductId.ToString(), //Kodun arkasında Dönene değer
                                           }).ToList();

            List<SelectListItem> values2 = (from x in context.Customers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CustomerName+" "+ x.CustomerSurname, // Ekranda Gözüken değer
                                                Value = x.CustomerId.ToString(), //Kodun arkasında Dönene değer
                                            }).ToList();

            List<SelectListItem> values3 = (from x in context.Personeles.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelName+" "+x.PersonelSurname, // Ekranda Gözüken değer
                                                Value = x.PersonelId.ToString(), //Kodun arkasında Dönene değer
                                            }).ToList();
            ViewBag.v1=values1;
            ViewBag.v2=values2;
            ViewBag.v3=values3;

            return View();
        }


        [HttpPost]
        public ActionResult AddSales(SalesMovements p)
        {

            p.Date= DateTime.Now;
            context.SalesMovements.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSales(int id)
        {
            List<SelectListItem> values1 = (from x in context.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName, // Ekranda Gözüken değer
                                                Value = x.ProductId.ToString(), //Kodun arkasında Dönene değer
                                            }).ToList();

            List<SelectListItem> values2 = (from x in context.Customers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CustomerName + " " + x.CustomerSurname, // Ekranda Gözüken değer
                                                Value = x.CustomerId.ToString(), //Kodun arkasında Dönene değer
                                            }).ToList();

            List<SelectListItem> values3 = (from x in context.Personeles.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelName + " " + x.PersonelSurname, // Ekranda Gözüken değer
                                                Value = x.PersonelId.ToString(), //Kodun arkasında Dönene değer
                                            }).ToList();
            ViewBag.v1 = values1;
            ViewBag.v2 = values2;
            ViewBag.v3 = values3;


            var value = context.SalesMovements.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSales(SalesMovements p)
        {
            var value = context.SalesMovements.Find(p.SalesId);
            value.Date = p.Date;
            value.Piece = p.Piece;
            value.Price = p.Price;
            value.Total = p.Total;
            value.Customerid = p.Customerid;
            value.Personelid = p.Personelid;
            value.Productid = p.Productid;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult DetailSales(int id)
        {
            var value = context.SalesMovements.Where(x => x.SalesId == id).ToList();
            return View(value);
        }





    }
}