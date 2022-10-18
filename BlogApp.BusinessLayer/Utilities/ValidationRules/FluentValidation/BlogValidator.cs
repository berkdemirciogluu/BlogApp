using BlogApp.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Utilities.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(250);
            RuleFor(x => x.Title).MinimumLength(5);
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();

        }
    }
}
