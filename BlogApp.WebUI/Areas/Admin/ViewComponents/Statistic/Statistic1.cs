using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            string openWheatherKey = "14ad2aba611dbef9c504b82a127794c5";
            string connectionToOpenWeather = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + openWheatherKey;
            XDocument document = XDocument.Load(connectionToOpenWeather);
            ViewBag.Temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
