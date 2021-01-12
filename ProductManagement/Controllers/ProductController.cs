using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Models;
using System.IO;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        ProductManagementEntities db = new ProductManagementEntities();
        // GET: Product
        public ActionResult Index()
        {
            try
            {
                if (Session["IsLogged"] == "1")
                {
                    ViewBag.TotalCategory = db.tblCategories.LongCount();
                    ViewBag.TotalProducts = db.tblProducts.LongCount();
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "UserAccount");
                }

            }
            catch (Exception _Exception)
            {
                TempData["ErrorMsg"] = _Exception.Message;
                return View();
            }

        }

        public ActionResult AddProduct()
        {
            try
            {
                if (Session["IsLogged"] == "1")
                {
                    ViewBag.CategoryList = new SelectList(db.tblCategories.ToList(), "Id", "CategoryName");
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "UserAccount");
                }
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMsg"] = _Exception.Message;
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddProduct(Products objPd, string LongDescription)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(objPd.ImageFile.FileName);
                string extension = Path.GetExtension(objPd.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                var temp = filename;
                objPd.SmallImage = "~/UserImage/" + filename;
                filename = Path.Combine(Server.MapPath("~/ShortImage/"), filename);
                objPd.ImageFile.SaveAs(filename);


                tblProduct objPd1 = new tblProduct();
                objPd1.SmallImage = temp;

                objPd1.CreatedDate = DateTime.Now;
                objPd1.UpdatedDate = DateTime.Now;
                objPd1.IsActive = true;
                objPd1.LongDescription = LongDescription;
                objPd1.Price = objPd.price;
                objPd1.Quantity = objPd.Quantaty;
                objPd1.ProductName = objPd.ProductName;
                objPd1.ShortDescription = objPd.ShortDescription;
                objPd1.CategoryId = objPd.Id;
                objPd.Id = 0;
                db.tblProducts.Add(objPd1);
                db.SaveChanges();
                TempData["SuccessMsg"] = objPd1.ProductName + " Successfully Added To Record!.....";
                return RedirectToAction("ProductList");
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMsg"] = _Exception.Message;
                return View();
            }
        }

        public ActionResult ProductList()
        {
            try
            {
                ViewBag.ProductList = (from pd in db.tblProducts
                                       join ct in db.tblCategories on pd.CategoryId equals ct.Id
                                       where pd.IsActive == true
                                       select new ProductList
                                       {
                                           Id = pd.Id,
                                           CategoryName = ct.CategoryName,
                                           CreatedDate = pd.CreatedDate.ToString(),
                                           ImagePath = pd.SmallImage,
                                           LongDescription = pd.LongDescription,
                                           Price = pd.Price,
                                           ProductName = pd.ProductName,
                                           Qty = pd.Quantity,
                                           ShortDescription = pd.ShortDescription,
                                           UpdatedDate = pd.UpdatedDate.ToString()
                                           
                                       }).ToList();
                return View();
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMsg"] = _Exception.Message;
                return View();
            }
        }
        public ActionResult Delete(int? Id)
        {
            try
            {

                var product = this.db.tblProducts.Find(Id);
                db.tblProducts.Remove(product);
                db.SaveChanges();
                TempData["SuccessMsg"] = "Delete Data Successfully...";
                return RedirectToAction("ProductList");
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMsg"] = _Exception.Message;
                return View();
            }
        }
        public ActionResult Edit(string Id)
        {
            try
            {
                ViewBag.CategoryList = new SelectList(db.tblCategories.ToList(), "Id", "CategoryName");
                int id = Convert.ToInt32(Id);
                tblProduct pc = db.tblProducts.Find(id);
                return PartialView("Edit",pc);
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMsg"] = _Exception.Message;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(tblProduct objProduct)
        {
            try
            {
                objProduct.UpdatedDate = DateTime.Now;

                db.Entry(objProduct).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMsg"] = objProduct.ProductName + " " + "Update successfully";
                return RedirectToAction("ProductList");
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMsg"] = _Exception.Message;
                return View();
            }
        }
        public ActionResult Details(string productId)
        {
            try
            {
                int id = Convert.ToInt32(productId);
                ViewBag.ProductList = (from pd in db.tblProducts
                                       join ct in db.tblCategories on pd.CategoryId equals ct.Id
                                       where pd.IsActive == true && pd.Id == id
                                       select new ProductList
                                       {
                                           Id = pd.Id,
                                           CategoryName = ct.CategoryName,
                                           CreatedDate = pd.CreatedDate.ToString(),
                                           ImagePath = pd.SmallImage,
                                           LongDescription = pd.LongDescription,
                                           Price = pd.Price,
                                           ProductName = pd.ProductName,
                                           Qty = pd.Quantity,
                                           ShortDescription = pd.ShortDescription,
                                           UpdatedDate = pd.UpdatedDate.ToString()

                                       }).ToList();
                return PartialView("Details");
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMsg"] = _Exception.Message;
                return View();
            }
        }
        public ActionResult DeleteAll(FormCollection objFormcollection)
        {
            try
            {
                string[] ids = objFormcollection["ID"].Split(new char[] { ',' });
                foreach (string id in ids)
                {
                    var products = db.tblProducts.Find(int.Parse(id));
                    db.tblProducts.Remove(products);
                    db.SaveChanges();
                }
                TempData["SuccessMsg"] = "Delete Data Successfully...";
                return RedirectToAction("ProductList");
            }
            catch (Exception _Exception)
            {
                TempData["ErrorMsg"] = _Exception.Message;
                return View();
            }
          
        }
    }
}