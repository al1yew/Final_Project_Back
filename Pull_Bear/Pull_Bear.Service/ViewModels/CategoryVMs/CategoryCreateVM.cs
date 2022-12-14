using FluentValidation;
using Microsoft.AspNetCore.Http;
using Pull_Bear.Service.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.CategoryVMs
{
    public class CategoryCreateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> MaleParentId { get; set; }
        public Nullable<int> FemaleParentId { get; set; }
        public int GenderId { get; set; }
        public IFormFile Photo { get; set; }

    }

    public class CategoryCreateVMValidator : AbstractValidator<CategoryCreateVM>
    {
        public CategoryCreateVMValidator()
        {
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

                    if (x.Photo == null)
                    {
                        y.AddFailure("Photo Is Required");
                    }

                    if (x.Photo != null)
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
                }
                else
                {
                    if (x.Photo != null)
                    {
                        y.AddFailure("Photo Is Required only for Main Category!");
                    }

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
            });

            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Gender is required!");
        }
    }
}