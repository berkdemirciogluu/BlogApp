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
    public class AuthorManager : IAuthorService
    {
        IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IResult Add(Author author)
        {
            _authorRepository.Add(author);
            return new SuccessResult(Messages.AuthorAdded);
        }

        public IResult Delete(Author entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Author>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Author> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
