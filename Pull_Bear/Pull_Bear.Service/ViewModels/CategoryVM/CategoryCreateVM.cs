﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.CategoryVM
{
    public class CategoryCreateVM
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int ParentId { get; set; }
    }

    public class CategoryCreateVMValidator : AbstractValidator<CategoryCreateVM>
    {
        public CategoryCreateVMValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required!")
                .MinimumLength(30).WithMessage("Category name must be at most 30 character!")
                .MinimumLength(1).WithMessage("Category name must be at least 1 character!");

            RuleFor(x => x).Custom((x, y) =>
            {
                if (x.IsMain && x.ParentId != null)
                {
                    y.AddFailure("IsMain", "You cannot choose Parent category for Main Category.");
                }
            });
        }
    }
}
