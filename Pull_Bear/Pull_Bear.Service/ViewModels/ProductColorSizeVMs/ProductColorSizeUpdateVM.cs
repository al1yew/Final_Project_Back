using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductColorSizeVMs
{
    public class ProductColorSizeUpdateVM
    {
        public int? Id { get; set; }
        public bool Color { get; set; }
        public bool Count { get; set; }
        public bool Size { get; set; }
        public int ChangeValue { get; set; }
    }
    public class ProductColorSizeUpdateVMValidator : AbstractValidator<ProductColorSizeUpdateVM>
    {
        public ProductColorSizeUpdateVMValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be null! We must know which row we are updating!");

            RuleFor(x => x.ChangeValue).GreaterThan(0).WithMessage("The value that you want to apply as updated must be bigger than 0!");

            //RuleFor(x => x).Custom((x, y) =>
            //{
            //    int color = x.Color ? 1 : 0;
            //    int size = x.Size ? 1 : 0;
            //    int count = x.Count ? 1 : 0;

            //    if (color + size + count > 1)
            //    {
            //        y.AddFailure("You cannot update more than 1 Product-Color-Size property!");
            //    }

            //});
        }
    }
}
