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

        public AuthorMessageNotification(IAuthorService commentService)
        {
            _authorService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
