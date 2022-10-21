using BlogApp.DataAccessLayer.Abstract;
using BlogApp.DataAccessLayer.Concrete.EnitityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.DataAccessLayer.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddDataAccessRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, EfCoreAuthorRepository>();
            services.AddScoped<IBlogRepository, EfCoreBlogRepository>();
            services.AddScoped<ICommentRepository, EfCoreCommentRepository>();
            services.AddScoped<IContactRepository, EfCoreContactRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<IAboutRepository, EfCoreAboutRepository>();
            services.AddScoped<INewsLetterRepository, EfCoreNewsLetterRepository>();
            services.AddScoped<INotificationRepository, EfCoreNotificationRepository>();
            services.AddScoped<IMessageRepository, EfCoreMessageRepository>();
            services.AddScoped<IMessage2Repository, EfCoreMessage2Repository>();
            services.AddScoped<IAdminRepository, EfCoreAdminRepository>();
        }
    }
}
