using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        IBlogService _blogService;
        IContactService _contactService;
        ICommentService _commentService;

        public Statistic1(IBlogService blogService, IContactService contactService, ICommentService commentService)
        {
            _blogService = blogService;
            _contactService = contactService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.TotalBlogCount = _blogService.GetAll().Count();
            ViewBag.TotalContactCount = _contactService.GetAll().Count();
            ViewBag.TotalCommentCount = _commentService.GetAll().Count();
            return View();
        }
    }
}
