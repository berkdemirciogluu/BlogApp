using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Abstract
{
    public interface IMessage2Service : IBaseService<Message2>
    {
        List<Message2> GetInboxMessagesByAuthor(int receiverId);
        List<Message2> GetSendboxMessagesByAuthor(int receiverId);
    }
}
