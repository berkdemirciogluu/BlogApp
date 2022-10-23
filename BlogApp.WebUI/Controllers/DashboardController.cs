using BlogApp.BusinessLayer.Abstract;
using BlogApp.DataAccessLayer.Context;
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

        public IActionResult Index()
        {
            DatabaseContext context = new DatabaseContext();
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Authors.Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
            ViewBag.BlogCount = _blogService.GetAll().Count().ToString();
            ViewBag.AuthorBlogCount = _blogService.GetBlogByAuthor(writerId).Count().ToString();
            ViewBag.CategoryCount = _categoryService.GetAll().Count().ToString();
            return View();
        }
    }
}
