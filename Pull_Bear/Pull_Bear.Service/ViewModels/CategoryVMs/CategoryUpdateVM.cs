using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Pull_Bear.Service.Enums;

namespace Pull_Bear.Service.ViewModels.CategoryVMs
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> MaleParentId { get; set; }
        public Nullable<int> FemaleParentId { get; set; }
        public int GenderId { get; set; }
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
                if (x.IsMain)
                {
                    if (x.MaleParentId != null || x.FemaleParentId != null)
                    {
                        y.AddFailure("You cannot choose parent category!");
                    }
                }
                else
                {
                    if (x.MaleParentId == null && x.FemaleParentId == null)
                    {
                        y.AddFailure("You Must choose parent category!");
                    }

                    if (x.FemaleParentId != null && x.MaleParentId != null)
                    {
                        y.AddFailure("You Must choose only one gender parent!");
                    }

                    if (x.GenderId == 1 && x.FemaleParentId == null && x.MaleParentId != null)
                    {
                        y.AddFailure("You must choose Female Parent Category!");
                    }

                    if (x.GenderId == 2 && x.FemaleParentId != null && x.MaleParentId == null)
                    {
                        y.AddFailure("You must choose Male Parent Category!");
                    }
                }

                if (x.Id == x.MaleParentId || x.Id == x.FemaleParentId)
                {
                    y.AddFailure("Parent id cannot be same as Id!");
                }
            });

            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Gender is required!");
        }
    }
}