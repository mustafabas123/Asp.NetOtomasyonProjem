using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;
using PagedList;

namespace OtomasyonProjesi.Controllers
{

    public class ProductController : Controller
    {
        ProjeContext context=new ProjeContext();

        public ActionResult Index(string p,int page=1)
        {
            var values=context.Products.Where(x =>x.State==true).ToList(); //Durumu true olanları listele
            if(p != null)
            {
                values=values.Where(y =>y.ProductName.Contains(p)).ToList();
            }
            return View(values);
        }


        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> values=(from x in context.Categories.ToList()select new SelectListItem {
                Text=x.CategoryName, // Ekranda Gözüken değer
                Value=x.CategoryId.ToString(), //Kodun arkasında Dönene değer
            }).ToList();

            ViewBag.value = values;

            return View();
        }


        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StateFalse(int id)
        {
            var value=context.Products.Find(id);
            value.State = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
			List<SelectListItem> values = (from x in context.Categories.ToList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName, // Ekranda Gözüken değer
											   Value = x.CategoryId.ToString(), //Kodun arkasında Dönene değer
										   }).ToList();
            ViewBag.value = values;
			var value= context.Products.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var value = context.Products.Find(product.ProductId);

            value.ProductName= product.ProductName;
            value.Mark= product.Mark;
            value.Stock= product.Stock;
            value.BuyingPrice= product.BuyingPrice;
            value.SellingPrice= product.SellingPrice;
            value.State= product.State;
            value.ImageUrl= product.ImageUrl;
            value.Categoryid = product.Categoryid;

            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult DoSell(int id)
        {
            List<SelectListItem> values1 = (from x in context.Personeles.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelName + " " + x.PersonelSurname, // Ekranda Gözüken değer
                                                Value = x.PersonelId.ToString(), //Kodun arkasında Dönene değer
                                            }).ToList();
            ViewBag.v1= values1;

            var value = context.Products.Find(id);
           
            ViewBag.v2= value.ProductId;
            ViewBag.v3= value.SellingPrice;

            return View();
        }

        [HttpPost]
        public ActionResult DoSell(SalesMovements p)
        {
            p.Date = DateTime.Now;
            context.SalesMovements.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index","Sales");
        }

    }
}