using BlogApp.BusinessLayer.Abstract;
using BlogApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        IAuthorService _authService;

        public RegisterController(IAuthorService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Author author)
        {
            author.Status = true;
            author.About = "Deneme";
            _authService.Add(author);
            return RedirectToAction("Index","Blogs");
        }
    }
}
