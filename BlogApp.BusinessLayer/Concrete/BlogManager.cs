using BlogApp.BusinessLayer.Abstract;
using BlogApp.BusinessLayer.Utilities.Messages;
using BlogApp.CoreLayer.Utilities.Results;
using BlogApp.DataAccessLayer.Abstract;
using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogRepository _blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public void Add(Blog blog)
        {
            _blogRepository.Add(blog);
        }

        public void Delete(int blogId)
        {
            var blogToDelete = _blogRepository.GetById(blogId);
            _blogRepository.Delete(blogToDelete);
        }

        public List<Blog> GetAll()
        {
            return _blogRepository.GetAll();
        }

        public List<Blog> GetBlogWithCategoryByAuthor(int authorId)
        {
            return _blogRepository.GetBlogWithCategoryByAuthor(authorId);
        }

        public List<Blog> GetLast3Blogs()
        {
            return _blogRepository.GetAll().Take(3).ToList();
        }

        public List<Blog> GetBlogByAuthor(int authorId)
        {
            return _blogRepository.GetAll(b => b.AuthorId == authorId);
        }

        public List<Blog> GetBlogWithCategory()
        {
            return _blogRepository.GetBlogWithCategory();
        }

        public Blog GetById(int id)
        {
            return _blogRepository.GetById(id);
        }

        public void Update(Blog blog)
        {
            _blogRepository.Update(blog);
        }
    }
}
