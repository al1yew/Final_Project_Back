using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.BodyFitVMs
{
    public class BodyFitCreateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
        public int GenderId { get; set; }
    }

    public class BodyFitCreateVMValidator : AbstractValidator<BodyFitCreateVM>
    {
        public BodyFitCreateVMValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Body Fit name is required!")
                .MaximumLength(30).WithMessage("Body Fit name must be at most 30 character!")
                .MinimumLength(1).WithMessage("Body Fit name must be at least 1 character!");

            RuleFor(x => x).Custom((x, y) =>
            {
                if (x.Photo == null)
                {
                    y.AddFailure("Photo Is Required");
                }
                else
                {
                    if (!x.Photo.ContentType.ToString().Contains("image/"))
                    {
                        y.AddFailure("Image must be only accepted IMAGE MIME types!");
                    }

                    if (x.Photo.Length / 1024 > 10000)
                    {
                        y.AddFailure("Image must be at most 10mb!");
                    }
                }
            });

            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Gender is required!");

        }
    }
}
