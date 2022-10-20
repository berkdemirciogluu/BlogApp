﻿using BlogApp.BusinessLayer.Abstract;
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

        public AuthorMessageNotification(IAuthorService authorService,IMessage2Service message2Service)
        {
            _authorService = authorService;
            _message2Service = message2Service;
        }

        public IViewComponentResult Invoke()
        {
            int receiverId = 3;
            return View(_message2Service.GetInboxMessagesByAuthor(receiverId));
        }
    }
}
