using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Manager.Interface;
using Business.Manager;
using BusinessEntities.Entities;
namespace ProductManagement.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryManager categoryManager;
        public CategoryController(ICategoryManager category)
        {
            categoryManager = category;
        }
        // GET: Category
        public ActionResult Index()
        {
            if (Session["IsLogged"] == "1")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public JsonResult AddCategory(string categoryname)
        {
            CategoryEntities ce = new CategoryEntities();
            ce.CategoryName = categoryname;
            ce.IsActive = true;
            var ConfirmAdded = categoryManager.AddCategory(ce);
            return Json(ConfirmAdded,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategory()
        {
            return Json(categoryManager.GetCategories().ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}