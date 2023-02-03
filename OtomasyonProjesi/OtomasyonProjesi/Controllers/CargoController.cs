using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;

namespace OtomasyonProjesi.Controllers
{
    public class CargoController : Controller
    {
        ProjeContext context=new ProjeContext();
        public ActionResult Index(string p)
        {
            var values = context.cargoDetails.ToList();
            if( p != null)
            {
                values=values.Where(x =>x.TrackingCode.Contains(p)).ToList();
            }
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCargo()
        {
            Random rnd=new Random();
            string[] karaketer = { "A", "B", "C", "D" };
            int k1,k2,k3,s1,s2,s3;

            k1= rnd.Next(0,karaketer.Length);
            k2=rnd.Next(0,karaketer.Length);
            k3=rnd.Next(0,karaketer.Length);

            s1 = rnd.Next(100, 999);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string TakipKodu = s1.ToString() + karaketer[k1] + s2.ToString() + karaketer[k2] + s3.ToString() + karaketer[k3];
            ViewBag.k1 = TakipKodu;

            return View();
        }
        [HttpPost]
        public ActionResult AddCargo(CargoDetail c)
        {
            context.cargoDetails.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult TracingCargo(string id)
        {
            var values=context.cargoTracks.Where(x =>x.TrackingCode== id).ToList();
            return View(values);
        }
            
    }
}