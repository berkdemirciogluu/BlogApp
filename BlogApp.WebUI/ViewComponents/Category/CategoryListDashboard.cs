﻿using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        ICategoryService _categoryService;

        public CategoryListDashboard(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoryService.GetAll());
        }
    }
}
