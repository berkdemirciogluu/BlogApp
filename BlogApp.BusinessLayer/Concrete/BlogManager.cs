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

        public IResult Add(Blog blog)
        {
            _blogRepository.Add(blog);
            return new SuccessResult(Messages.BlogAdded);
        }

        public IResult Delete(int blogId)
        {
            var blogToDelete = _blogRepository.GetById(blogId);
            _blogRepository.Delete(blogToDelete);
            return new SuccessResult(Messages.BlogDeleted);
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogRepository.GetAll(), Messages.BlogListed);
        }

        public IDataResult<List<Blog>> GetBlogWithCategoryByAuthor(int authorId)
        {
            return new SuccessDataResult<List<Blog>>(_blogRepository.GetBlogWithCategoryByAuthor(authorId), Messages.BlogListed);
        }

        public IDataResult<List<Blog>> GetLast3Blogs()
        {
            return new SuccessDataResult<List<Blog>>(_blogRepository.GetAll().Take(3).ToList(), Messages.BlogListed);
        }

        public IDataResult<List<Blog>> GetBlogByAuthor(int authorId)
        {
            return new SuccessDataResult<List<Blog>>(_blogRepository.GetAll(b => b.AuthorId == authorId), Messages.BlogListed);
        }

        public IDataResult<List<Blog>> GetBlogWithCategory()
        {
            return new SuccessDataResult<List<Blog>>(_blogRepository.GetBlogWithCategory(), Messages.BlogListed);
        }

        public IDataResult<Blog> GetById(int id)
        {
            return new SuccessDataResult<Blog>(_blogRepository.GetById(id), Messages.BlogListed);
        }

        public IResult Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
