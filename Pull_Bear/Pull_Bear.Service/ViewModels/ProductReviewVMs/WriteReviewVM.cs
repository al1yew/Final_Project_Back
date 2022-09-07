﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductReviewVMs
{
    public class WriteReviewVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Review { get; set; }
        public double Rating { get; set; }
        public List<IFormFile> Photos { get; set; }
    }

    public class WriteReviewVMValidator : AbstractValidator<WriteReviewVM>
    {
        public WriteReviewVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required!");
            RuleFor(x => x.Review).NotEmpty().WithMessage("Review is required!");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Rating is required!");
        }
    }
}
