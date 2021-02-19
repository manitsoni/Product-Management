using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.Repository.Interface;
using Data.Repository;
using BusinessEntities.Entities;

namespace Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ProductManagementEntities db = new ProductManagementEntities();
        public bool AddProduct(tblProduct product)
        {
            db.tblProducts.Add(product);
            return db.SaveChanges() > 0;
        }
        public IQueryable<tblCategory> GetCategories()
        {
            return db.tblCategories;
        }
        public List<ProductList> GetProducts()
        {
            var ProductList = (from pd in db.tblProducts
                                   join ct in db.tblCategories on pd.CategoryId equals ct.Id
                                   where pd.IsActive == true
                                   select new ProductList
                                   {
                                       Id = pd.Id,
                                       CategoryName = ct.CategoryName,
                                       CreatedDate = pd.CreatedDate.ToString(),
                                       ImagePath = pd.ImagePath,
                                       LongDescription = pd.LongDescription,
                                       Price = pd.Price,
                                       ProductName = pd.ProductName,
                                       Qty = pd.Quantity,
                                       ShortDescription = pd.ShortDescription,
                                       UpdatedDate = pd.UpdatedDate.ToString()

                                   }).ToList();
            return ProductList;
        }

        public List<ProductList> GetProductsById(int id)
        {
            var ProductList = (from pd in db.tblProducts
                               join ct in db.tblCategories on pd.CategoryId equals ct.Id
                               where pd.IsActive == true && pd.Id == id
                               select new ProductList
                               {
                                   Id = pd.Id,
                                   CategoryName = ct.CategoryName,
                                   CreatedDate = pd.CreatedDate.ToString(),
                                   ImagePath = pd.ImagePath,
                                   LongDescription = pd.LongDescription,
                                   Price = pd.Price,
                                   ProductName = pd.ProductName,
                                   Qty = pd.Quantity,
                                   ShortDescription = pd.ShortDescription,
                                   UpdatedDate = pd.UpdatedDate.ToString()

                               }).ToList();
            return ProductList;
        }
    }
}
