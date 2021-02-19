using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.Repository.Interface;
using Data.Repository;
namespace Data.Repository
{
   public  class CategoryRepository : ICategoryRepository
    {
        private ProductManagementEntities db = new ProductManagementEntities();
        public bool AddCategory(tblCategory category)
        {
            db.tblCategories.Add(category);
            return db.SaveChanges() > 0;
        }

        public IQueryable<tblCategory> GetCategories()
        {
            return db.tblCategories;
        }
    }
}
