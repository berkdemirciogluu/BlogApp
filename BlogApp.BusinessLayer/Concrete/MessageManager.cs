using BlogApp.BusinessLayer.Abstract;
using BlogApp.DataAccessLayer.Abstract;
using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageRepository _messageRepository;

        public MessageManager(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void Add(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAll()
        {
            return _messageRepository.GetAll();
        }

        public List<Message> GetInboxMessagesByAuthor(string receiver)
        {
            return _messageRepository.GetAll(x=>x.Receiver == receiver);
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
