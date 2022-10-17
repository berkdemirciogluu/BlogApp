using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class CommentsController : Controller
    {
        ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        public PartialViewResult GetCommentsByBlog(int blogId)
        {
            return PartialView(_commentService.GetCommentsByBlogId(blogId));
        }
    }
}
