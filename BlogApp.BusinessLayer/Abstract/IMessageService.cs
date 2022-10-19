using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Abstract
{
    public interface IMessageService : IBaseService<Message>
    {
        List<Message> GetInboxMessagesByAuthor(string receiver);
    }
}
