﻿using BlogApp.BusinessLayer.Abstract;
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

        public AuthorAboutOnDashboard(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_authorService.GetById(1));
        }
    }
}