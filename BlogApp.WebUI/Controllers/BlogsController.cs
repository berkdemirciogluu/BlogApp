using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
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
    }
}
