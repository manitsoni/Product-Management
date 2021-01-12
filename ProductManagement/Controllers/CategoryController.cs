using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Models;
namespace ProductManagement.Controllers
{
    public class CategoryController : Controller
    {
        ProductManagementEntities db = new ProductManagementEntities();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCategory()
        {
            try
            {
                if (Session["IsLogged"] == "1")
                {
                    ViewBag.CategoryList = db.tblCategories.ToList();
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "UserAccount");
                }
                
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMessage"] = _Exception.Message;
                return View();
            }
           
        }
        [HttpPost]
        public ActionResult AddCategory(Category objCt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblCategory objCt1 = new tblCategory();
                    objCt1.Createddate = DateTime.Now;
                    objCt1.CategoryName = objCt.CategoryName;
                    db.tblCategories.Add(objCt1);
                    db.SaveChanges();
                    TempData["SuccessMsg"] = objCt.CategoryName + " Added Successful.....!";
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ViewBag.CategoryList = db.tblCategories.ToList();
                    return View();
                }
               
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMessage"] = _Exception.Message;
                return View();
            }
        }
    }
}