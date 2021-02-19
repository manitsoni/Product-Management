using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Business.Manager;
using Business.Manager.Interface;
using Business.Repository_Helper;
namespace ProductManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ILoginManager, LoginManager>();
            container.RegisterType<ICategoryManager, CategoryManager>();
            container.RegisterType<IProductManager, ProductManager>();
            container.AddNewExtension<UnityRepositoryHelper>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}