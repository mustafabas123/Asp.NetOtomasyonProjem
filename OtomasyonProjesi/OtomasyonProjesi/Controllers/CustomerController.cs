using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;

namespace OtomasyonProjesi.Controllers
{

    public class CustomerController : Controller
    {
        ProjeContext context=new ProjeContext();

        public ActionResult Index()
        {
            var values =context.Customers.Where(x =>x.State==true).ToList();
            return View(values);
        }
        public ActionResult StateFalse(int id)
        {
            var value = context.Customers.Find(id);
            value.State = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles ="b")]
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            customer.State = true;
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            var value=context.Customers.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            if(!ModelState .IsValid)
            {
                return View();
            }
            var value = context.Customers.Find(customer.CustomerId);

            value.CustomerName = customer.CustomerName;
            value.CustomerSurname= customer.CustomerSurname;
            value.CustomerCity= customer.CustomerCity;
            value.CustomerMail= customer.CustomerMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DetailCustomer(int id)
        {
            var customerName =context.Customers.Where(x =>x.CustomerId ==id).Select(y => y.CustomerName +" "+ y.CustomerSurname).FirstOrDefault();
            var values=context.SalesMovements.Where(x =>x.Customerid==id).ToList();
            ViewBag.v1 = customerName;
            return View(values);
        }

	}
}