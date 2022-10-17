using BlogApp.CoreLayer.Utilities.Results;
using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Abstract
{
    public interface IBlogService
    {
        IDataResult<List<Blog>> GetAll();
        IDataResult<List<Blog>> GetBlogWithCategory();
        IDataResult<List<Blog>> GetBlogByAuthor(int authorId);
        IDataResult<Blog> GetById(int id);
        IResult Add(Blog blog);
        IResult Delete(Blog blog);
        IResult Update(Blog blog);
    }
}
