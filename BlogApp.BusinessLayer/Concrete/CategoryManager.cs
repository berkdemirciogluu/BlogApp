using BlogApp.BusinessLayer.Abstract;
using BlogApp.BusinessLayer.Utilities.Messages;
using BlogApp.CoreLayer.Utilities.Results;
using BlogApp.DataAccessLayer.Abstract;
using BlogApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BlogApp.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {

            _categoryRepository.Add(category);
        }

        public void Delete(int id)
        {
            var categoryToDelete = _categoryRepository.GetById(id);
            _categoryRepository.Delete(categoryToDelete);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public List<SelectListItem> GetCategoryById()
        {
            List<SelectListItem> categoryValues = (from category in _categoryRepository.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = category.Name,
                                                       Value = category.Id.ToString()

                                                   }).ToList();
            return categoryValues;
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
