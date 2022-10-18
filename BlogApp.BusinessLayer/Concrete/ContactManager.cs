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
    public class ContactManager : IContactService
    {
        IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IResult Add(Contact contact)
        {
            _contactRepository.Add(contact);
            return new SuccessResult(Messages.ContactAdded);
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Contact>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Contact> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
