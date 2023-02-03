using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;
namespace OtomasyonProjesi.Controllers
{
    public class DepartmanController : Controller
    {
        ProjeContext context=new ProjeContext();

        public ActionResult Index()
        {
            var values=context.Departments.Where(x =>x.State ==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddDepartman()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartman(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StatePasif(int id)
        {
            var value = context.Departments.Find(id);
            value.State = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateDepartman(int id)
        {
            var value=context.Departments.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateDepartman(Department p)
        {
            var value= context.Departments.Find(p.DepartmentId);
            value.DepartmentName = p.DepartmentName;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DetailDepartman(int id)
        {
            var values = context.Personeles.Where(x => x.Departmentid == id).ToList();
            var DepartmanNaame = context.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.v1 = DepartmanNaame;
            return View(values);
        }
        public ActionResult SellingDepartman(int id)
        {
            var values=context.SalesMovements.Where(x =>x.SalesId== id).ToList();
            var PersonelName =context.Personeles.Where(x =>x.PersonelId ==id).Select(y =>y.PersonelName).FirstOrDefault();
            ViewBag.v2 = PersonelName;
            return View(values);
        }
	}
}