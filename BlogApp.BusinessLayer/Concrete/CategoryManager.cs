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

        public IResult Add(Category category)
        {

            _categoryRepository.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(int id)
        {
            var categoryToDelete = _categoryRepository.GetById(id);
            _categoryRepository.Delete(categoryToDelete);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryRepository.GetAll(), Messages.CategoryListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryRepository.GetById(id), Messages.CategoryListed);
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

        public IResult Update(Category category)
        {
            _categoryRepository.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
