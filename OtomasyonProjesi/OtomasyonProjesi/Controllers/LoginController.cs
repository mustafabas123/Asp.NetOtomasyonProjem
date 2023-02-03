using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtomasyonProjesi.Models.Classlar;

namespace OtomasyonProjesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        ProjeContext context = new ProjeContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
     
        [HttpGet]

        public PartialViewResult RegisterPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult RegisterPartial(Customer c)
        {
            context.Customers.Add(c);
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult LoginPartial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPartial(Customer c)
        {
            var info = context.Customers.FirstOrDefault(x => x.CustomerMail == c.CustomerMail && x.CustomerPassword == c.CustomerPassword);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.CustomerMail, false);
                Session["CustomerMail"] = info.CustomerMail.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
            else
            {
                return View("Index", "Login");
            }
        }
  
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var info = context.Admins.FirstOrDefault(x => x.AdminName == a.AdminName && x.AdminPassword == a.AdminPassword);
            if(info != null)
            {
                FormsAuthentication.SetAuthCookie(info.AdminName, false);
                Session["AdminName"] = info.AdminName.ToString();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return View("Index", "Login");
            }
        }
    }
}