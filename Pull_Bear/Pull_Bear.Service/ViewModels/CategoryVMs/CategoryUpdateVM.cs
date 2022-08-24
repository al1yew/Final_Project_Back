using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.CategoryVMs
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }
    }

    public class CategoryUpdateVMValidator : AbstractValidator<CategoryUpdateVM>
    {
        public CategoryUpdateVMValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required!");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required!")
                .MaximumLength(30).WithMessage("Category name must be at most 30 character!")
                .MinimumLength(1).WithMessage("Category name must be at least 1 character!");

            RuleFor(x => x).Custom((x, y) =>
            {
                if (x.IsMain && x.ParentId != null)
                {
                    y.AddFailure("IsMain", "You cannot choose Parent category for Main Category.");
                }

                if (!x.IsMain && x.ParentId == null)
                {
                    y.AddFailure("ParentId", "You must choose Parent Category for Child Category!");
                }

                if (x.Id == x.ParentId)
                {
                    y.AddFailure("ParentId", "Parent id cannot be same as Id!");
                }
            });
        }
    }
}
