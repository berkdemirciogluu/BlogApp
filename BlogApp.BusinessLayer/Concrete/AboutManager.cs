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
    public class AboutManager : IAboutService
    {
        IAboutRepository _aboutRepository;

        public AboutManager(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public IResult Add(About entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(About entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(_aboutRepository.GetAll(), Messages.AboutListed);
        }

        public IDataResult<About> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(About entity)
        {
            throw new NotImplementedException();
        }
    }
}
