using BlogApp.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        ICommentService _commentService;

        public CommentListByBlog(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_commentService.GetCommentsByBlogId(6));
        }
    }
}
