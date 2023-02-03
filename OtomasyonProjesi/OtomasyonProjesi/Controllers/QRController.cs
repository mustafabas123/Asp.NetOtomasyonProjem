using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtomasyonProjesi.Controllers
{

    public class QRController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kod)
        { //QR OLuşturma
            using(MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator kodUret= new QRCodeGenerator();
                QRCodeGenerator.QRCode Karekod = kodUret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = Karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodImage="data:image/png;base64,"+Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}