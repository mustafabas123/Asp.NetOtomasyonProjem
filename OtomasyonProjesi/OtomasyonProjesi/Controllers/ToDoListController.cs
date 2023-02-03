using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;

namespace OtomasyonProjesi.Controllers
{

    public class ToDoListController : Controller
    {
        ProjeContext context = new ProjeContext();
        // GET: ToDoList
        public ActionResult Index()
        {

            var value1=context.Customers.Count().ToString();   // Müşteri sayısıı
            var value2=context.Products.Count().ToString();    // Ürün sayııs
            var value3=context.Categories.Count().ToString() ; // Kategori Sayısı
            var value4=(from x in context.Customers select x.CustomerCity).Distinct().Count().ToString(); // Kaç farklı şehirden Müşteri Vardır 

            ViewBag.v1=value1; 
            ViewBag.v2=value2;
            ViewBag.v3=value3;
            ViewBag.v4=value4;

            var values = context.ToDoLists.ToList();
            return View(values);
        }
    }
}