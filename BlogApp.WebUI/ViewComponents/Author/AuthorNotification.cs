using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.ViewComponents.Author
{
    public class AuthorNotification : ViewComponent
    {
        INotificationService _notificationService;

        public AuthorNotification(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_notificationService.GetAll());
        }
    }
}
