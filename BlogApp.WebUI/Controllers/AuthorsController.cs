using BlogApp.BusinessLayer.Abstract;
using BlogApp.BusinessLayer.Utilities.ValidationRules.FluentValidation;
using BlogApp.DataAccessLayer.Context;
using BlogApp.EntityLayer.Concrete;
using BlogApp.WebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class AuthorsController : Controller
    {
        IAuthorService _authorService;
        IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public AuthorsController(IAuthorService authorService, UserManager<AppUser> userManager, IUserService userService)
        {
            _authorService = authorService;
            _userManager = userManager;
            _userService = userService;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.userMail = userMail;
            ViewBag.userName = _authorService.GetAll().Where(x => x.Email == userMail).Select(y => y.Name).FirstOrDefault();
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

        [HttpGet]
        public IActionResult AuthorEditProfile()
        {
            var userName = User.Identity.Name;
            var userMail = _userService.GetAll().Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var userId = _userService.GetAll().Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
            return View(_userService.GetById(userId));
        }

        [HttpPost]        
        public IActionResult AuthorEditProfile(Author author)
        {
            AuthorValidator validator = new AuthorValidator();
            ValidationResult result = validator.Validate(author);
            if (result.IsValid)
            {
                _authorService.Update(author);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddAuthor(AddProfileImage pAuthor)
        {
            Author author = new Author();
            if (pAuthor!=null)
            {
                var extension = Path.GetExtension(pAuthor.Image.FileName);
                var newImageName = Guid.NewGuid()+extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                pAuthor.Image.CopyTo(stream);
                author.Image = newImageName;
            }
            author.Email = pAuthor.Email;
            author.Name = pAuthor.Name;
            author.Password = pAuthor.Password;
            author.Status = true;
            _authorService.Add(author);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
