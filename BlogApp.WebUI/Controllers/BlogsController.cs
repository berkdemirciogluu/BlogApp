using BlogApp.BusinessLayer.Abstract;
using BlogApp.BusinessLayer.Utilities.ValidationRules.FluentValidation;
using BlogApp.CoreLayer.Utilities.Results;
using BlogApp.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogsController : Controller
    {
        IBlogService _blogService;
        ICategoryService _categoryService;

        public BlogsController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_blogService.GetBlogWithCategory());
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.id = id;
            return View(_blogService.GetById(id));
        }

        public IActionResult BlogListByAuthor()
        {
            return View(_blogService.GetBlogWithCategoryByAuthor(1));
        }
        [HttpGet]
        public IActionResult AddBlog()
        {
            ViewBag.categoryValues = _categoryService.GetCategoryById();
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            BlogValidator authorValidator = new BlogValidator();
            ValidationResult results = authorValidator.Validate(blog);
            if (results.IsValid)
            {
                blog.Status = true;
                blog.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.AuthorId = 1;
                _blogService.Add(blog);
                return RedirectToAction("BlogListByAuthor", "Blogs");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            _blogService.Delete(id);
            return RedirectToAction("BlogListByAuthor");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            return View(_blogService.GetById(id).Data);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            return RedirectToAction("BlogListByAuthor");
        }
    }
}
