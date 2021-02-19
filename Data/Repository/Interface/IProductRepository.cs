using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using BusinessEntities.Entities;
namespace Data.Repository.Interface
{
    public interface IProductRepository
    {
        bool AddProduct(tblProduct product);
        List<ProductList> GetProducts();
        IQueryable<tblCategory> GetCategories();

        List<ProductList> GetProductsById(int id);
    }
}
