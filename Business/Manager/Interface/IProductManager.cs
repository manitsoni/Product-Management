using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Entities;
namespace Business.Manager.Interface
{
    public interface IProductManager
    {
        bool AddProduct(ProductEntities product);
        IList<ProductList> GetProducts();
        IList<CategoryEntities> GetCategories();
        IList<ProductList> GetProductById(int id);
    }
}
