using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.ViewComponents.Author
{
    public class AuthorMessageNotification : ViewComponent
    {
        IAuthorService _authorService;
        IMessage2Service _message2Service;
        IUserService _userService;

        public AuthorMessageNotification(IAuthorService authorService,IMessage2Service message2Service, IUserService userService)
        {
            _authorService = authorService;
            _message2Service = message2Service;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userMail = _userService.GetAll().Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var userId = _authorService.GetAll().Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
            return View(_message2Service.GetInboxMessagesByAuthor(userId));
        }
    }
}
