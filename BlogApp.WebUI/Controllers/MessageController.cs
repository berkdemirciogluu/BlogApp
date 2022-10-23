using BlogApp.BusinessLayer.Abstract;
using BlogApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
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

        public IActionResult MessageDetails(int id)
        {
            
            return View(_message2Service.GetById(id));
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 message)
        {
            var userName = User.Identity.Name;
            var userMail = _userService.GetAll().Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var userId = _authorService.GetAll().Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
            message.SenderId = userId;
            message.ReceiverId = 1;
            message.Status = true;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _message2Service.Add(message);
            return RedirectToAction("Inbox");
        }
    }
}
