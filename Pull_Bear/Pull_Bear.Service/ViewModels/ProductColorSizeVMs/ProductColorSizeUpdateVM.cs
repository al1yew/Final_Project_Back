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
        }
    }
}
