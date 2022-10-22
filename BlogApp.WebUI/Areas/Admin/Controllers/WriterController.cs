using BlogApp.BusinessLayer.Abstract;
using BlogApp.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        IAuthorService _authorService;

        public WriterController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var writers = _authorService.GetAll();
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterById(int writerId)
        {
            var writers = _authorService.GetAll();
            var writer = writers.FirstOrDefault(x => x.Id == writerId);
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass writer)
        {
            writersStatic.Add(writer);
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult DeleteWriter(int id)
        {
            _authorService.Delete(id);
            return RedirectToAction("Index", "Writer");
        }

        public IActionResult UpdateWriter(WriterClass writer)
        {
            var writerUpdate = _authorService.GetById(writer.Id);
            writerUpdate.Name = writer.Name;
            _authorService.Update(writerUpdate);
            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writersStatic = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name = "Ayşe"
            },
            new WriterClass
            {
                Id = 2,
                Name = "Ahmet"
            },
            new WriterClass
            {
                Id = 3,
                Name = "Buse"
            }
        };
    }
}
