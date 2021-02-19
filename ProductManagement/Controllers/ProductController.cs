using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Manager.Interface;
using Business.Manager;
using BusinessEntities.Entities;
using System.IO;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager productManager;
        public ProductController(IProductManager product)
        {
            productManager = product;
        }
        // GET: Product
        public ActionResult Index()
        {
            if (Session["IsLogged"] == "1")
            {
                ViewBag.TotalProduct = productManager.GetProducts().LongCount();
                ViewBag.TotalCategory = productManager.GetCategories().LongCount();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult AddProduct()
        {
            if (Session["IsLogged"] == "1")
            {
                ViewBag.CategoryList = new SelectList(productManager.GetCategories().ToList(), "Id", "CategoryName");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult AddProduct(ProductEntities pe)
        {
            string filename = Path.GetFileNameWithoutExtension(pe.ImageFile.FileName);
            string extension = Path.GetExtension(pe.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            var temp = filename;
            pe.ImagePath = "~/UserImage/" + filename;
            filename = Path.Combine(Server.MapPath("~/ShortImage/"), filename);
            pe.ImageFile.SaveAs(filename);

            pe.ImagePath = temp;
            pe.CategoryId = pe.Id;
            pe.CreatedDate = DateTime.Now;
            pe.UpdatedDate = DateTime.Now;
            pe.IsActive = true;
            var ConfirmAdded = productManager.AddProduct(pe);
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductList()
        {
            ViewBag.List = productManager.GetProducts().ToList();
            return View();
        }

        public ActionResult Details(string productId)
        {
            int id = Convert.ToInt32(productId);
            ViewBag.ProductList = productManager.GetProductById(id).ToList();
            return PartialView("Details");
        }
        public ActionResult Edit(string Id)
        {
            try
            {
                ViewBag.CategoryList = new SelectList(productManager.GetCategories().ToList(), "Id", "CategoryName");
                int id = Convert.ToInt32(Id);
                List<ProductList> pc = productManager.GetProductById(id).ToList();
                return PartialView("Edit", pc);
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMsg"] = _Exception.Message;
                return View();
            }
        }
    }
}