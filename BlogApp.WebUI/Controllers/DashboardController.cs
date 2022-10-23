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
        IUserService _userService;
        IAuthorService _authorService;

        public DashboardController(IBlogService blogService, ICategoryService categoryService, IUserService userService, IAuthorService authorService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userService = userService;
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var userMail = _userService.GetAll().Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _authorService.GetAll().Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
            ViewBag.BlogCount = _blogService.GetAll().Count().ToString();
            ViewBag.AuthorBlogCount = _blogService.GetBlogByAuthor(writerId).Count().ToString();
            ViewBag.CategoryCount = _categoryService.GetAll().Count().ToString();
            return View();
        }
    }
}
