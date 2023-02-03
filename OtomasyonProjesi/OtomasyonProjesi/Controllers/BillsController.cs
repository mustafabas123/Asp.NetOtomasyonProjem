using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;

namespace OtomasyonProjesi.Controllers
{
    public class BillsController : Controller
    {
        ProjeContext context=new ProjeContext();

        public ActionResult Index()
        {
            var values=context.Bills.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult AddBills()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddBills(Bills b)
        {
            context.Bills.Add(b);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBills(int id)
        {
            var value=context.Bills.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateBills(Bills b)
        {
            var value = context.Bills.Find(b.BillsId);

            value.BillsSeriNo= b.BillsSeriNo;
            value.BillsSiraNo= b.BillsSiraNo;
            value.BillsDate= b.BillsDate;
            value.TaxAdministration = b.TaxAdministration;
            value.Clock= b.Clock;
            value.submitterName= b.submitterName;
            value.deliveryName= b.deliveryName;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DetailBills(int id)
        {
            var value= context.FaturaKalem.Where(x =>x.Billsid==id).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
            context.FaturaKalem.Add(f);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DynamicBills()
        {
            DynamicBills Db= new DynamicBills();
            Db.Bills = context.Bills.ToList();
            Db.FaturaKalems=context.FaturaKalem.ToList();
            return View(Db);
        }
        public ActionResult SaveBills(string BillsSeriNo, string BillsSiraNo, DateTime BillsDate, string TaxAdministration, string Clock, string submitterName, string deliveryName, string Total, FaturaKalem[] kalemler)
        {
            Bills b=new Bills();
            b.BillsSeriNo= BillsSeriNo;
            b.BillsSiraNo= BillsSiraNo;
            b.BillsDate= BillsDate;
            b.TaxAdministration = TaxAdministration;
            b.Clock = Clock;
            b.deliveryName= deliveryName;
            b.submitterName = submitterName;
            b.Total = Convert.ToDecimal(Total);
            context.Bills.Add(b);
            foreach(var item in kalemler)
            {
                FaturaKalem fk=new FaturaKalem();
                fk.Aciklama= item.Aciklama;
                fk.Miktar= item.Miktar;
                fk.BirimFiyat= item.BirimFiyat;
                fk.Tutar= item.Tutar;
                fk.Billsid= item.Billsid;
                context.FaturaKalem.Add(fk);
            }
            context.SaveChanges();
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);


        }
    }
}