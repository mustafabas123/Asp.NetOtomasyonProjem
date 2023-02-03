using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;
namespace OtomasyonProjesi.Controllers
{

    public class StatisticsController : Controller
    {
        ProjeContext context=new ProjeContext();
        public ActionResult Index()
        {
            
            var value1=context.Customers.Count().ToString();  //Müşteri Sayısını Bulmamızı sağlayan kod bloğu
            var value2=context.Products.Count().ToString();  //Ürün Sayısı bulmamızı sağlayan kod bloğu
            var value3=context.Personeles.Count().ToString(); //Persoenl Sayısı bulmamızı sağlayan kod bloğu
            var value4=context.Categories.Count().ToString();  //Kategori sayısını bulmamızı sağlayan kod bloğu
            var value5=context.Products.Sum(x =>x.Stock).ToString(); //Ürün tablosu içindeki bütün stockları toplamını bulma kodu
            var value6=(from x in context.Products select x.Mark).Distinct().Count().ToString(); //ürünler tablosundaki markaları tekrarsız olarak say
            var value7 = context.Products.Where(x => x.Stock <= 100).Count().ToString(); //Ürün sayısı 20 nin altında olan ürünleri sayısını getir
            var value8=(from x in context.Products orderby x.BuyingPrice descending select x.ProductName).FirstOrDefault(); //En yüksek fiyatlı ürünün adını getirme kodu
            var value9 = (from x in context.Products orderby x.BuyingPrice ascending select x.ProductName).FirstOrDefault();
            var value10=context.Products.Count(x =>x.ProductName == "Buzdolabı").ToString();
            var value11 = context.Products.Count(x => x.ProductName == "Laptop").ToString();
            var value12=context.Products.GroupBy(x =>x.Mark).OrderByDescending(z =>z.Count()).Select(y =>y.Key).FirstOrDefault(); // En fazla markası olan markanın adını göster
            
            var value13 = context.Products.Where(u => u.ProductId == (
            context.SalesMovements.GroupBy(x => x.Productid).
            OrderByDescending(z => z.Count()).Select(y => y.Key).  // 
            FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();



            var value14=context.SalesMovements.Sum(x =>x.Total).ToString(); //Satış hareketlerdeki Toplam Tutar

            DateTime bugun = DateTime.Today;
            ViewBag.Bugun = bugun;
            var value15 = context.SalesMovements.Count(x => x.Date == bugun).ToString(); //Bugün yapılan satışların sayısı
           var value16 = context.SalesMovements.Where(x => x.Date == bugun).Sum(y => (decimal?) y.Total).ToString();  // Bugün yapılan satışların toplamı

            ViewBag.d1 = value1;
            ViewBag.d2 = value2;
            ViewBag.d3 = value3;
            ViewBag.d4 = value4;
            ViewBag.d5 = value5;
            ViewBag.d6 = value6;
            ViewBag.d7 = value7;
            ViewBag.d8 = value8;
            ViewBag.d9 = value9;
            ViewBag.d10 = value10;
            ViewBag.d11 = value11;
            ViewBag.d12 = value12;
            ViewBag.d13 = value13;
            ViewBag.d14=value14;
            ViewBag.d15 = value15;
            ViewBag.d16 = value16;  

            return View();
        }
        public ActionResult SimpleTable()
        {
            var query = from x in context.Customers group x by x.CustomerCity into g select new ClassGrup
            { //Müşteriler tablosu içinde seç ve gruplandır x e göre gruplandır.ilk gruplandırma kriteri müşteri şehri yap ve g değişkeni içine ata ve sınıf ismini seç

                City = g.Key,
                Count = g.Count()
        };
            return View(query.ToList());
        }
        public PartialViewResult Partial1()
        {
            //her bir departmanda kaç tane personelimizi olduğunu liteleme komutu
            var query2 = from x in context.Personeles
                         group x by x.Departments.DepartmentName into g
                         select new ClassGrup2
                         {
                             DepartmanName = g.Key,
                             DepartmanCount = g.Count()
                         };
            return PartialView(query2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var values = context.Customers.ToList();
            return PartialView(values);
        }
        public PartialViewResult Partial3()
        {
            var values=context.Products.ToList();
            return PartialView(values);
        }
        public PartialViewResult Partial4()
        {
            var query3 = from x in context.Products
                         group x by x.Mark into g
                         select new ClassGrup3
                         {
                             Marka = g.Key,
                             CountMarka = g.Count()
                         };
            return PartialView(query3.ToList());
        }
    }
}