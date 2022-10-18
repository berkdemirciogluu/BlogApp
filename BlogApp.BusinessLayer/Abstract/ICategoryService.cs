using BlogApp.CoreLayer.Utilities.Results;
using BlogApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Abstract
{
    public interface ICategoryService : IBaseService<Category>
    {
        List<SelectListItem> GetCategoryById();
    }
}
