﻿using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLayer.Abstract
{
    public interface IMessage2Repository : IGenericRepository<Message2>
    {
        List<Message2> GetMessageWithByAuthor(int authorId);
        List<Message2> GetSendboxWithByAuthor(int authorId);
    }

}
