using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        IMessage2Service _message2Service;
        IUserService _userService;
        IAuthorService _authorService;

        public MessageController(IMessage2Service message2Service, IUserService userService, IAuthorService authorService)
        {
            _message2Service = message2Service;
            _userService = userService;
            _authorService = authorService;
        }
        public IActionResult Inbox()
        {
            var userName = User.Identity.Name;
            var userMail = _userService.GetAll().Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var userId = _authorService.GetAll().Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
            return View(_message2Service.GetInboxMessagesByAuthor(userId));
        }
        public IActionResult Sendbox()
        {
            var userName = User.Identity.Name;
            var userMail = _userService.GetAll().Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var userId = _authorService.GetAll().Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
            return View(_message2Service.GetSendboxMessagesByAuthor(userId));
        }

        public IActionResult ComposeMessage()
        {
            
            return View();
        }
    }
}
