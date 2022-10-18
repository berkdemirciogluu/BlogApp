using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        IBlogService _blogService;
        ICategoryService _categoryService;

        public DashboardController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.BlogCount = _blogService.GetAll().Data.Count().ToString();
            ViewBag.AuthorBlogCount = _blogService.GetBlogByAuthor(1).Data.Count().ToString();
            ViewBag.CategoryCount = _categoryService.GetAll().Data.Count().ToString();
            return View();
        }
    }
}
