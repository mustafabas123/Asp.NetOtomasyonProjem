using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;

namespace OtomasyonProjesi.Controllers
{

    public class ProductDetailController : Controller
    {

        ProjeContext context=new ProjeContext();
        Class1 cs=new Class1();

        public ActionResult Index()
        {

            cs.value1 = context.Products.Where(x => x.ProductId == 1).ToList();
            cs.value2=context.Details.Where(y => y.DetailId ==1).ToList();

            return View(cs);
        }
    }
}