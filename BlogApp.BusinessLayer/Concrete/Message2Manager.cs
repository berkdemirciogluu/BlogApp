﻿using BlogApp.BusinessLayer.Abstract;
using BlogApp.DataAccessLayer.Abstract;
using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Repository _message2Repository;

        public Message2Manager(IMessage2Repository message2Repository)
        {
            _message2Repository = message2Repository;
        }

        public void Add(Message2 entity)
        {
            _message2Repository.Add(entity);
        }

        public void Delete(int id)
        {
            _message2Repository.Delete(id);
        }

        public List<Message2> GetAll()
        {
            return _message2Repository.GetAll();
        }

        public List<Message2> GetInboxMessagesByAuthor(int receiverId)
        {
            return _message2Repository.GetMessageWithByAuthor(receiverId);
        }

        public Message2 GetById(int id)
        {
            return _message2Repository.GetById(id);
        }

        public void Update(Message2 entity)
        {
            _message2Repository.Update(entity);
        }

        public List<Message2> GetSendboxMessagesByAuthor(int receiverId)
        {
            return _message2Repository.GetSendboxWithByAuthor(receiverId);
        }
    }
}
