using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Manager.Interface;
using Business.Manager;
namespace ProductManagement.Controllers
{
    public class HomeController : Controller
    {
        private ILoginManager loginManager;
        public HomeController(ILoginManager login)
        {
            loginManager = login;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            bool isLogin = loginManager.Login(email, password);
            if (isLogin == true)
            {
                TempData["SuccessMsg"] = "Welcome " + email;
                Session["UserName"] = email;
                Session["IsLogged"] = "1";
                return RedirectToAction("Index","Product");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "You Are Login Success...";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}