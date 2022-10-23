using BlogApp.BusinessLayer.Abstract;
using BlogApp.DataAccessLayer.Context;
using BlogApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.ViewComponents.Author
{
    public class AuthorAboutOnDashboard : ViewComponent
    {
        IAuthorService _authorService;
        IUserService _userService;

        public AuthorAboutOnDashboard(IAuthorService authorService, IUserService userService)
        {
            _authorService = authorService;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.Username = userName;
            var userMail = _userService.GetAll().Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault(); 
            var userId = _authorService.GetAll().Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
            return View(_authorService.GetById(userId));
        }
    }
}
