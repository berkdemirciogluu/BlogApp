using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLayer.Abstract
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        List<Blog> GetBlogWithCategory();

    }
}
