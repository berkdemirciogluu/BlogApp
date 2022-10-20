using BlogApp.DataAccessLayer.Abstract;
using BlogApp.DataAccessLayer.Context;
using BlogApp.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLayer.Concrete.EnitityFrameworkCore
{
    public class EfCoreMessage2Repository : EfCoreGenericRepository<Message2, DatabaseContext>, IMessage2Repository
    {
        public List<Message2> GetMessageWithByAuthor(int authorId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Message2s.Include(x => x.AuthorSender).Where(x => x.SenderId == authorId).ToList();
            }
        }
    }
}
