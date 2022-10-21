using BlogApp.BusinessLayer.Abstract;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blogs List");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Name";

                int blogRowCount = 2;
                foreach (var item in _blogService.GetAll())
                {
                    worksheet.Cell(blogRowCount, 1).Value = item.Id;
                    worksheet.Cell(blogRowCount, 2).Value = item.Title;
                    blogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogList.xlsx");
                }
            }
            return View();
        }

        public IActionResult GetExcelBlogList()
        {
            return View();
        }
    }
}
