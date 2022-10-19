using BlogApp.DataAccessLayer.Abstract;
using BlogApp.DataAccessLayer.Context;
using BlogApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLayer.Concrete.EnitityFrameworkCore
{
    public class EfCoreNotificationRepository : EfCoreGenericRepository<Notification,DatabaseContext> , INotificationRepository
    {
    }
}
