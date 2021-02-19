using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Manager.Interface;
using Business.Repository_Helper;
using Data.Model;
using Data.Repository.Interface;
using Data.Repository;
using BusinessEntities.Entities;

namespace Business.Manager
{
    public class ProductManager : IProductManager
    {
        private IProductRepository productRepository;
        public ProductManager(IProductRepository product)
        {
            productRepository = product;
        }
        public bool AddProduct(ProductEntities product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductEntities, tblProduct>());
            IMapper mapper = config.CreateMapper();
            tblProduct products = mapper.Map<ProductEntities, tblProduct>(product);
            return productRepository.AddProduct(products);
        }
        public IList<ProductList> GetProducts()
        {
            return productRepository.GetProducts().ToList();
        }
        public IList<CategoryEntities> GetCategories()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<tblCategory, CategoryEntities>());
            IMapper mapper = config.CreateMapper();
            var vehicaltype = productRepository.GetCategories().ToList();
            List<CategoryEntities> CategoryList = vehicaltype.Select(x => mapper.Map<tblCategory, CategoryEntities>(x)).ToList();
            return CategoryList;
        }

        public IList<ProductList> GetProductById(int id)
        {
            return productRepository.GetProductsById(id).ToList();
        }
    }
}
