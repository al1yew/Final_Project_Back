using FluentValidation;
using Microsoft.AspNetCore.Http;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.GenderVMs;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductImageVMs;
using Pull_Bear.Service.ViewModels.ProductToTagVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductVMs
{
    public class ProductUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string PhotoModelIndicators { get; set; }
        public string Composition { get; set; }
        public string Care { get; set; }
        public string Description { get; set; }


        //boolean
        public bool IsHotSale { get; set; }
        public bool IsNew { get; set; }
        public bool IsPreOrder { get; set; }


        //image loading 
        public IFormFile ProductPhoto { get; set; }
        public IFormFile MainPhoto1 { get; set; }
        public IFormFile MainPhoto2 { get; set; }
        public List<IFormFile> Files { get; set; }


        //relations one ... - many products
        public CategoryGetVM Category { get; set; }
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public Nullable<int> MaleCategoryId { get; set; }
        public Nullable<int> FemaleCategoryId { get; set; }
        public BodyFitGetVM BodyFit { get; set; }
        public int BodyFitId { get; set; }
        public Nullable<int> MaleBodyFitId { get; set; }
        public Nullable<int> FemaleBodyFitId { get; set; }
        public int GenderId { get; set; }


        //relations one product - many ...
        public List<ProductImageGetVM> ProductImages { get; set; }

        //relations many to many
        public List<ProductColorSizeGetVM> ProductColorSizes { get; set; }
        public List<ProductToTagGetVM> ProductToTags { get; set; }


        //props for help 
        public List<int> TagIds { get; set; }
        public List<int> ColorIds { get; set; }
        public List<int> SizeIds { get; set; }
        public List<int> Counts { get; set; }
    }

    public class ProductUpdateVMValidator : AbstractValidator<ProductUpdateVM>
    {
        public ProductUpdateVMValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is vital for creating product!")
                .MaximumLength(40).WithMessage("Product Name must be at most 40 symbols!");

            RuleFor(x => x.Care)
               .NotEmpty().WithMessage("Care is vital for creating product!")
               .MaximumLength(255).WithMessage("Product Care text must be at most 255 symbols!");

            RuleFor(x => x.Composition)
              .NotEmpty().WithMessage("Composition is vital for creating product!")
              .MaximumLength(100).WithMessage("Product Composition text must be at most 100 symbols!");

            RuleFor(x => x.Description)
             .NotEmpty().WithMessage("Description is vital for creating product!")
             .MaximumLength(255).WithMessage("Product Description text must be at most 255 symbols!");

            RuleFor(x => x.PhotoModelIndicators)
             .NotEmpty().WithMessage("Photo Model Indicators is vital for creating product!")
             .MaximumLength(255).WithMessage("Photo Model Indicators must be at most 255 symbols!");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required!");

            RuleFor(x => x).Custom((x, y) =>
            {
                if (x.ProductPhoto != null)
                {
                    if (!x.ProductPhoto.ContentType.ToString().Contains("image/"))
                    {
                        y.AddFailure("Image must be only accepted IMAGE MIME types!");
                    }

                    if (x.ProductPhoto.Length / 1024 > 10000)
                    {
                        y.AddFailure("Image must be at most 10mb!");
                    }
                }

                if (x.MainPhoto2 != null)
                {
                    if (!x.MainPhoto2.ContentType.ToString().Contains("image/"))
                    {
                        y.AddFailure("Image must be only accepted IMAGE MIME types!");
                    }

                    if (x.MainPhoto2.Length / 1024 > 10000)
                    {
                        y.AddFailure("Image must be at most 10mb!");
                    }
                }

                if (x.MainPhoto1 != null)
                {
                    if (!x.MainPhoto1.ContentType.ToString().Contains("image/"))
                    {
                        y.AddFailure("Image must be only accepted IMAGE MIME types!");
                    }

                    if (x.MainPhoto1.Length / 1024 > 10000)
                    {
                        y.AddFailure("Image must be at most 10mb!");
                    }
                }

                if (x.Files != null)
                {
                    foreach (IFormFile formFile in x.Files)
                    {
                        if (!formFile.ContentType.ToString().Contains("image/"))
                        {
                            y.AddFailure("Image must be only accepted IMAGE MIME types!");
                        }

                        if (formFile.Length / 1024 > 10000)
                        {
                            y.AddFailure("Image must be at most 10mb!");
                        }
                    }
                }

                if (x.Price <= x.DiscountPrice)
                {
                    y.AddFailure("Discount price must be less than real price!");
                }

                if (x.Counts != null && x.Counts.Count > 0)
                {
                    foreach (int count in x.Counts)
                    {
                        if (count <= 0)
                        {
                            y.AddFailure("To add product you must enter count!");
                        }
                    }
                }

                if (x.ColorIds != null && x.SizeIds != null && x.Counts != null)
                {
                    if (x.ColorIds.Count > 0 && x.SizeIds.Count > 0 && x.Counts.Count > 0)
                    {
                        if (x.ColorIds.Count != x.Counts.Count || x.ColorIds.Count != x.SizeIds.Count || x.Counts.Count != x.SizeIds.Count)
                        {
                            y.AddFailure("You must enter Count, Size and Color values respectively!");
                        }
                    }
                    else if (!(x.SizeIds.Count >= 0 && x.Counts.Count >= 0 && x.ColorIds.Count >= 0))
                    {
                        y.AddFailure("You must enter Count, Size and Color values respectively!");
                    }
                }


            });

        }
    }
}
