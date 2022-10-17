using BlogApp.BusinessLayer.Abstract;
using BlogApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class NewsLettersController : Controller
    {
        INewsLetterService _newsLetterService;

        public NewsLettersController(INewsLetterService cnewsLetterService)
        {
            _newsLetterService = cnewsLetterService;
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.Status = true;
            _newsLetterService.Add(newsLetter);
            return PartialView();
        }
    }
}
