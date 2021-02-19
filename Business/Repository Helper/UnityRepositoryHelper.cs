using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;
using Data.Repository;
using Data.Repository.Interface;
namespace Business.Repository_Helper
{
   public  class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ILoginRepository, LoginRepository>();
            Container.RegisterType<ICategoryRepository, CategoryRepository>();
            Container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}
