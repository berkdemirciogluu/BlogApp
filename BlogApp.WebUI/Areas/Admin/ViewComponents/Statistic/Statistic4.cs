using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        IAdminService _adminService;

        public Statistic4(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.AdminName = _adminService.GetAll().Where(x=>x.Id==1).Select(y=>y.Name).FirstOrDefault();
            ViewBag.AdminImage = _adminService.GetAll().Where(x=>x.Id==1).Select(y=>y.Image).FirstOrDefault();
            ViewBag.AdminDescription = _adminService.GetAll().Where(x=>x.Id==1).Select(y=>y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
