using BlogApp.CoreLayer.Utilities.Results;
using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Abstract
{
    public interface IBlogService : IBaseService<Blog>
    {
        IDataResult<List<Blog>> GetLast3Blogs();
        IDataResult<List<Blog>> GetBlogWithCategory();
        IDataResult<List<Blog>> GetBlogByAuthor(int authorId);
        IDataResult<List<Blog>> GetBlogWithCategoryByAuthor(int authorId);
    }
}
