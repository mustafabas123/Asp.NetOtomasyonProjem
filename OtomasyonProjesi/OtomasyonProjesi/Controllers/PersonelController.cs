using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtomasyonProjesi.Models.Classlar;
using PagedList;
using WebGrease.Css.Extensions;

namespace OtomasyonProjesi.Controllers
{

    public class PersonelController : Controller
    {
        ProjeContext context=new ProjeContext();

        public ActionResult Index(int page=1)
        {
            var values=context.Personeles.ToList().ToPagedList(page,4);
            return View(values);
        }



        [HttpGet]
        public ActionResult AddPersonel()
        {
            List<SelectListItem> value =(from x in context.Departments.ToList()select new SelectListItem
            {
                Text=x.DepartmentName,
                Value=x.DepartmentId.ToString(),
            }).ToList();
            ViewBag.v1=value;
            return View();
        }


        [HttpPost]
        public ActionResult AddPersonel(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string road="~/Image/"+fileName+extension;
                Request.Files[0].SaveAs(Server.MapPath(road));
                personel.ImageUrl = "/Image/" + fileName + extension;
            }
            context.Personeles.Add(personel);
                context.SaveChanges();
                return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdatePersonel(int id)
        {
            var value=context.Personeles.Find(id);

            List<SelectListItem> departmanName = (from x in context.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName,
                                              Value = x.DepartmentId.ToString(),
                                          }).ToList();
            ViewBag.v1 = departmanName;

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdatePersonel(Personel personel)
        {
            var value = context.Personeles.Find(personel.PersonelId);
            value.PersonelName=personel.PersonelName;
            value.PersonelSurname=personel.PersonelSurname;
            value.ImageUrl=personel.ImageUrl;
            value.Departmentid = personel.Departmentid;
            value.PersonelAdress=personel.PersonelAdress;
            value.PersonelPhone=personel.PersonelPhone;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ContactPersonel()
        {
            var values = context.Personeles.ToList();
            return View(values);
        }
    }
}