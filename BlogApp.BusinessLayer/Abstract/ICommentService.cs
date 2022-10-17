using BlogApp.CoreLayer.Utilities.Results;
using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();
        IDataResult<Comment> GetById(int id);
        IResult Add(Comment comment);
        //IResult Delete(Comment comment);
        //IResult Update(Comment comment);
        IDataResult<List<Comment>> GetCommentsByBlogId(int blogId);
        
    }
}
