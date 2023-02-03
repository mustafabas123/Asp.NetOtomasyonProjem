using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;

namespace OtomasyonProjesi.Controllers
{

    public class GrafiklerController : Controller
    {
        ProjeContext context=new ProjeContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stock Sayısı").AddLegend("Stock").AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" },
                yValues: new[] { 85, 66, 98 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xValue= new ArrayList();
            ArrayList yValue=new ArrayList();
            var result=context.Products.ToList();
            result.ToList().ForEach(x => xValue.Add(x.ProductName));
            result.ToList().ForEach(x =>yValue.Add(x.Stock));
            var grafik=new Chart(600, 600).AddTitle("Stocklar").AddSeries(chartType:"pie",name:"Stock",xValue:xValue,yValues:yValue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        [HttpGet]
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(),JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(),JsonRequestBehavior.AllowGet);
        }


        //Ürünler tablosundaki bir ürünün stock değerini grafiğe aktarma sağlayan kod bloğu
        public List<GrafikClass2> UrunListesi2()
        {
            List<GrafikClass2> snf=new List<GrafikClass2>();
            using(var context=new ProjeContext())
            {
                snf = context.Products.Select(x => new GrafikClass2
                {
                    ProductName = x.ProductName,
                    Stock = x.Stock,
                }).ToList();
            }
            return snf;
        }
        public List<GrafikClass> UrunListesi()
        {
            List<GrafikClass> snf=new List<GrafikClass>();
            snf.Add(new GrafikClass()
            {
                ProductName="Bilgisayar",
                Stock=20
            });
            snf.Add(new GrafikClass()
            {
                ProductName = "Telefon",
                Stock = 40
            });
            snf.Add(new GrafikClass()
            {
                ProductName = "Tablet",
                Stock = 50
            });
            snf.Add(new GrafikClass()
            {
                ProductName = "Televizyon",
                Stock = 13
            });
            snf.Add(new GrafikClass()
            {
                ProductName = "Buzdolabı",
                Stock = 56
            });
            snf.Add(new GrafikClass()
            {
                ProductName = "Çamaşır Makinesi",
                Stock = 23
            });
            return snf;
        }
    }
}