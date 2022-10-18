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
    public class CommentManager : ICommentService
    {
        ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IResult Add(Comment comment)
        {
            _commentRepository.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentRepository.GetAll(), Messages.CommentListed);
        }

        public IDataResult<Comment> GetById(int id)
        {
            return new SuccessDataResult<Comment>(_commentRepository.GetById(id), Messages.CommentListed);
        }

        public IDataResult<List<Comment>> GetCommentsByBlogId(int blogId)
        {
            return new SuccessDataResult<List<Comment>>(_commentRepository.GetAll(x=>x.BlogId == blogId), Messages.CommentListed);
        }

        public IResult Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
