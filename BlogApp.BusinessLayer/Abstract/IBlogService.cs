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
        List<Blog> GetLast3Blogs();
        List<Blog> GetBlogWithCategory();
        List<Blog> GetBlogByAuthor(int authorId);
        List<Blog> GetBlogWithCategoryByAuthor(int authorId);
    }
}
