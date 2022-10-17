using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.ViewComponents.Blog
{
    public class AuthorRecentBlogs : ViewComponent
    {
        IBlogService _blogService;

        public AuthorRecentBlogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_blogService.GetBlogByAuthor(1));
        }
    }
}
