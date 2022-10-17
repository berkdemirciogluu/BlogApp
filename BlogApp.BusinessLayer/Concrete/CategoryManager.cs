using BlogApp.BusinessLayer.Abstract;
using BlogApp.BusinessLayer.Utilities.Messages;
using BlogApp.CoreLayer.Utilities.Results;
using BlogApp.DataAccessLayer.Abstract;
using BlogApp.EntityLayer.Concrete;
using System.Collections.Generic;

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

        public IResult Delete(Category category)
        {
            _categoryRepository.Delete(category);
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

        public IResult Update(Category category)
        {
            _categoryRepository.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
