using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Entities;
namespace Business.Manager.Interface
{
    public interface ICategoryManager
    {
        bool AddCategory(CategoryEntities category);
        IList<CategoryEntities> GetCategories();
    }
}
