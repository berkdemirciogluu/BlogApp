using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class AuthorsController : Controller
    {
        IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult AuthorNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult AuthorFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public IActionResult AuthorEditProfile()
        {
            return View(_authorService.GetById(1));
        }
    }
}
