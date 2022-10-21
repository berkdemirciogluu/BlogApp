using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        IBlogService _blogService;

        public Statistic2(IBlogService blogService, IContactService contactService, ICommentService commentService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.LatestAddedBlog = _blogService.GetAll().OrderByDescending(x=>x.Id).Select(x=>x.Title).Take(1).FirstOrDefault();
            return View();
        }
    }
}
