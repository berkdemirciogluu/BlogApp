using BlogApp.CoreLayer.Utilities.Results;
using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int id);
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
