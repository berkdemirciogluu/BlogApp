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
        public async Task<IActionResult> AuthorEditProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.Email = user.Email;
            model.NameSurname = user.NameSurname;
            model.ImageUrl = user.ImageUrl;
            model.Username = user.UserName;
            return View(model);
        }

        [HttpPost]        
        public async Task<IActionResult> AuthorEditProfile(UserUpdateViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Email = model.Email;
            user.NameSurname = model.NameSurname;
            user.ImageUrl = model.ImageUrl;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Dashboard");   
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
