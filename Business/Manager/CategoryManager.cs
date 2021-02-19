using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Manager.Interface;
using Business.Manager;
using AutoMapper;
using Data.Repository.Interface;
using Data.Repository;
using BusinessEntities.Entities;
using Data.Model;
namespace Business.Manager
{
    public class CategoryManager : ICategoryManager
    {
        private ICategoryRepository categoryRepository;
        public CategoryManager(ICategoryRepository repository)
        {
            categoryRepository = repository;
        }
        public bool AddCategory(CategoryEntities category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CategoryEntities, tblCategory>());
            IMapper mapper = config.CreateMapper();
            bool IsAvailable = false;
            var Category = GetCategories().ToList();
            var name = category.CategoryName;
            foreach (var item in Category)
            {
                if (item.CategoryName == name)
                {
                    IsAvailable = true;
                    break;
                }
            }
            if (IsAvailable == false)
            {
                tblCategory categories = mapper.Map < CategoryEntities, tblCategory>(category);
                return categoryRepository.AddCategory(categories);
            }
            return IsAvailable;
        }

        public IList<CategoryEntities> GetCategories()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<tblCategory, CategoryEntities>());
            IMapper mapper = config.CreateMapper();
            var vehicaltype = categoryRepository.GetCategories().ToList();
            List<CategoryEntities> CategoryList = vehicaltype.Select(x => mapper.Map<tblCategory, CategoryEntities>(x)).ToList();
            return CategoryList;
        }
    }
}
