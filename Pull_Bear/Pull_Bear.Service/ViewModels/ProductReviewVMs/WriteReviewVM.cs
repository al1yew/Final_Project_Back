using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductReviewVMs
{
    public class WriteReviewVM
    {
        public string Review { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AppUserId { get; set; }
        public double Rating { get; set; }
        public List<IFormFile> Photos { get; set; }
    }

    public class WriteReviewVMValidator : AbstractValidator<WriteReviewVM>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WriteReviewVMValidator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
                RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required!");
            }

            RuleFor(x => x.Review).NotEmpty().WithMessage("Review is required!");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Rating is required!");

            RuleFor(x => x).Custom((a, b) =>
            {
                if (a.Photos != null)
                {
                    if (a.Photos.Count > 3)
                    {
                        b.AddFailure("You can add max 3 photos!");
                    }
                }
            });
        }
    }
}
