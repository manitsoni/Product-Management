using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Models;
namespace ProductManagement.Controllers
{
    public class UserAccountController : Controller
    {
        ProductManagementEntities db = new ProductManagementEntities();
        // GET: UserAccount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            try
            {
                var user = db.UserDatas.Where(m => m.EmailId == email && m.Password == password).FirstOrDefault();
                if (user != null)
                {
                    TempData["SuccessMsg"] = "Welcome" + email;
                    Session["UserName"] = email;
                    Session["IsLogged"] = "1";
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    TempData["IncorrectUser"] = "Incorrect Username Or Password!";
                }
                return View();
            }
            catch (Exception _Exception)
            {
                TempData["errormessage"] = _Exception.Message;
                return View();
            }
        }
    }
}