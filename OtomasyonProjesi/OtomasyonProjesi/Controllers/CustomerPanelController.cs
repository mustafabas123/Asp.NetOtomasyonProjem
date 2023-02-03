using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtomasyonProjesi.Models.Classlar;

namespace OtomasyonProjesi.Controllers
{

    public class CustomerPanelController : Controller
    {

        ProjeContext context = new ProjeContext();

        
        public ActionResult Index()
        {
            var CustomerMail = (string)Session["CustomerMail"];
            var value = context.Messages.Where(x => x.Alici == CustomerMail).ToList();
            ViewBag.v1 = CustomerMail;

            var value2 = context.Customers.Where(x => x.CustomerMail == CustomerMail).Select(y => y.CustomerId).FirstOrDefault();
            ViewBag.v2 = value2;

            var value3 = context.SalesMovements.Where(x => x.Customerid == value2).Count();
            ViewBag.v3 = value3;

            var value4 = context.SalesMovements.Where(x => x.Customerid == value2).Sum(y => y.Total);
            ViewBag.v4 = value4;

            var value5 = context.SalesMovements.Where(x => x.Customerid == value2).Sum(y => y.Piece);
            ViewBag.v5 = value5;

            var NameSurname = context.Customers.Where(x => x.CustomerMail == CustomerMail).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.Namesurname = NameSurname;

            
            return View(value);
        }
        [HttpGet]
        public ActionResult Order()
        {
            var CutomerMail = (string)Session["CustomerMail"];
            var id =context.Customers.Where(x =>x.CustomerMail ==CutomerMail.ToString()).Select(y =>y.CustomerId).FirstOrDefault();  //Session ile gelen mail adresini id'sini bul ve bu id yi bir var id değişkenine ata
            var values = context.SalesMovements.Where(x => x.Customerid == id).ToList(); //satış hareketler tablosundaki müşteri id si eşit olan değerleri listele ve values değişkenine ata
            return View(values);
        }
        public ActionResult MessageinComing()
        {
            var CutomerMail = (string)Session["CustomerMail"];
            var values=context.Messages.Where(x=>x.Alici == CutomerMail).OrderByDescending(y=>y.tarih).ToList();
            var incomingMessage = context.Messages.Count(x=>x.Alici==CutomerMail);
            ViewBag.v1 = incomingMessage;
            var outMessage = context.Messages.Count(x => x.Gonderici == CutomerMail);
            ViewBag.v2 = outMessage;
            return View(values);
        }
        public ActionResult OutgoingMessages()
        {
            var CutomerMail = (string)Session["CustomerMail"];
            var values = context.Messages.Where(x => x.Gonderici == CutomerMail).OrderByDescending(y=>y.tarih).ToList();
            var incomingMessage = context.Messages.Count(x => x.Alici == CutomerMail);
            ViewBag.v1 = incomingMessage;
            var outMessage = context.Messages.Count(x => x.Gonderici == CutomerMail);
            ViewBag.v2 = outMessage;
            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            var value=context.Messages.Where(x =>x.MessageId== id).ToList();
            var CutomerMail = (string)Session["CustomerMail"];

            var incomingMessage = context.Messages.Count(x => x.Alici == CutomerMail);
            ViewBag.v1 = incomingMessage;

            var outMessage = context.Messages.Count(x => x.Gonderici == CutomerMail);
            ViewBag.v2 = outMessage;

            return View(value);
        }
        [HttpGet]
        public ActionResult AddMessage()
        {
            var CutomerMail = (string)Session["CustomerMail"];
            var incomingMessage = context.Messages.Count(x => x.Alici == CutomerMail);
            ViewBag.v1 = incomingMessage;

            var outMessage = context.Messages.Count(x => x.Gonderici == CutomerMail);
            ViewBag.v2 = outMessage;
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(Message m)
        {
            var CutomerMail = (string)Session["CustomerMail"];
            m.tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = CutomerMail;
            context.Messages.Add(m);
            context.SaveChanges();
            return View();
        }
        public ActionResult TracingCargo(string p)
        {
            var values = context.cargoDetails.Where(x=>x.TrackingCode.Contains(p)).ToList();
            return View(values);
        }
        public ActionResult CustomerTracingCargo(string id)
        {
            var value=context.cargoTracks.Where(x =>x.TrackingCode==id).ToList();
            return View(value);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult PartialView1()
        {
            var CutomerMail = (string)Session["CustomerMail"];
            var id = context.Customers.Where(x => x.CustomerMail == CutomerMail).Select(y => y.CustomerId).FirstOrDefault();
            var values = context.Customers.Find(id);
            return PartialView("PartialView1", values);
        }
        public ActionResult UpdateCustomer(Customer c)
        {
            var values = context.Customers.Find(c.CustomerId);

            values.CustomerName = c.CustomerName;
            values.CustomerSurname= c.CustomerSurname;
            values.CustomerMail = c.CustomerMail;
            values.CustomerCity= c.CustomerCity;
            values.CustomerPassword = c.CustomerPassword;
            context.SaveChanges();
            return RedirectToAction("Index","Login");
        }
        public PartialViewResult PartialView2()
        {
            var values=context.News.ToList();
            return PartialView(values);
        }
    }
}