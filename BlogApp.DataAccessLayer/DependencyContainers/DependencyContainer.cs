using BlogApp.DataAccessLayer.Abstract;
using BlogApp.DataAccessLayer.Concrete.EnitityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLayer.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddDataAccessRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBlogRepository, EfCoreBlogRepository>();
            services.AddScoped<ICommentRepository, EfCoreCommentRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
        }
    }
}
