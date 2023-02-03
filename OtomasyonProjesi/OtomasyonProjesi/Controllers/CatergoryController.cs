using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;
using PagedList;
using PagedList.Mvc;

namespace OtomasyonProjesi.Controllers
{

    public class CatergoryController : Controller
    {
        ProjeContext contex=new ProjeContext();
        public ActionResult Index(int page = 1)
        {
            var values = contex.Categories.ToList().ToPagedList(page, 4); // (başlangıç sayfası,sayfadan bulunması istediğin kategori adeti)
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            contex.Categories.Add(c);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var value=contex.Categories.Find(id);
            contex.Categories.Remove(value);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = contex.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category c)
        {
            var value = contex.Categories.Find(c.CategoryId);
            value.CategoryName = c.CategoryName;
            contex.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Deneme()
        {
            DropDownListClass Ddlc = new DropDownListClass();
            Ddlc.Categories = new SelectList(contex.Categories, "CategoryId", "CategoryName");
            Ddlc.Products = new SelectList(contex.Products, "ProductId", "ProductName");
            return View(Ddlc);
        }
        public JsonResult GetProduct(int p)
        {
            var ProductList = (from x in contex.Products
                               join y in contex.Categories on x.Category.CategoryId equals y.CategoryId
                               where x.Category.CategoryId == p
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductId.ToString()
                               }).ToList();
            return Json(ProductList, JsonRequestBehavior.AllowGet);
        }
	}
}