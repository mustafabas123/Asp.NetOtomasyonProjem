using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;
namespace OtomasyonProjesi.Controllers
{

    public class GaleryController : Controller
    {
        ProjeContext context=new ProjeContext();
        // GET: Galery
        public ActionResult Index()
        {
            var values=context.Products.ToList();
            return View(values);
        }
    }
}