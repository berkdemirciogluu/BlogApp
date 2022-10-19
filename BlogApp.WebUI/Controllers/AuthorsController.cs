using BlogApp.BusinessLayer.Abstract;
using BlogApp.BusinessLayer.Utilities.ValidationRules.FluentValidation;
using BlogApp.EntityLayer.Concrete;
using BlogApp.WebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        public IActionResult AuthorEditProfile()
        {
            return View(_authorService.GetById(1));
        }

        [AllowAnonymous]
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
