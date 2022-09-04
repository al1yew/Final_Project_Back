using FluentValidation;
using Microsoft.AspNetCore.Http;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.GenderVMs;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductImageVMs;
using Pull_Bear.Service.ViewModels.ProductReviewVMs;
using Pull_Bear.Service.ViewModels.ProductToTagVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductVMs
{
    public class ProductCreateVM
    {
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
        public IFormFile ShopPhoto { get; set; }
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
        public GenderGetVM Gender { get; set; }
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

    public class ProductCreateVMValidator : AbstractValidator<ProductCreateVM>
    {
        public ProductCreateVMValidator()
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

            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Gender must be choosen!");

            RuleFor(x => x).Custom((x, y) =>
            {
                if (x.ProductPhoto == null && x.MainPhoto1 == null && x.MainPhoto2 == null && x.Files == null && x.ShopPhoto == null)
                {
                    y.AddFailure("All Photos are required for better sales!");
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

                if (x.ShopPhoto != null)
                {
                    if (!x.ShopPhoto.ContentType.ToString().Contains("image/"))
                    {
                        y.AddFailure("Image must be only accepted IMAGE MIME types!");
                    }

                    if (x.ShopPhoto.Length / 1024 > 10000)
                    {
                        y.AddFailure("Image must be at most 10mb!");
                    }
                }

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

                if (x.Files != null)
                {
                    if (x.Files.Count > 4)
                    {
                        y.AddFailure("You can select only 4 Product Images!");
                    }

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

                if (x.GenderId == 1 && !(x.FemaleBodyFitId == null && x.FemaleCategoryId == null) && (x.MaleCategoryId != null || x.MaleBodyFitId != null))
                {
                    y.AddFailure("For choosen Female gender there must be female body fit and female category!");
                }

                if (x.GenderId == 2 && !(x.MaleBodyFitId == null && x.MaleCategoryId == null) && (x.FemaleCategoryId != null || x.FemaleBodyFitId != null))
                {
                    y.AddFailure("For choosen Female gender there must be female body fit and female category!");
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
