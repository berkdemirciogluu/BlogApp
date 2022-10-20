using BlogApp.BusinessLayer.Abstract;
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

        public MessageController(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }
        [AllowAnonymous]
        public IActionResult Inbox()
        {
            int receiverId = 3;
            return View(_message2Service.GetInboxMessagesByAuthor(receiverId));
        }

        public IActionResult MessageDetails(int id)
        {
            
            return View(_message2Service.GetById(id));
        }
    }
}
