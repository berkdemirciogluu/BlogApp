using BlogApp.BusinessLayer.Abstract;
using BlogApp.BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Utilities.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<IAdminService, AdminManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<INewsLetterService, NewsLetterManager>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessage2Service, Message2Manager>();
        }
    }
}
