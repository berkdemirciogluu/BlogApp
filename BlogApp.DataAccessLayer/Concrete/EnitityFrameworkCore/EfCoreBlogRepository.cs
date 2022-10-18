using BlogApp.DataAccessLayer.Abstract;
using BlogApp.DataAccessLayer.Context;
using BlogApp.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLayer.Concrete.EnitityFrameworkCore
{
    public class EfCoreBlogRepository : EfCoreGenericRepository<Blog, DatabaseContext>, IBlogRepository
    {
        public List<Blog> GetBlogWithCategory()
        {

            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetBlogWithCategoryByAuthor(int authorId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Blogs.Include(x => x.Category).Where(x=>x.AuthorId == authorId).ToList();
            }
        }
    }
}
