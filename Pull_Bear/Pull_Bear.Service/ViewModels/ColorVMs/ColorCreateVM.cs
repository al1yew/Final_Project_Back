using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ColorVMs
{
    public class ColorCreateVM
    {
        public string HexCode { get; set; }
        public string Name { get; set; }
    }

    public class ColorCreateVMValidator : AbstractValidator<ColorCreateVM>
    {
        public ColorCreateVMValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Color name is required!")
                .MaximumLength(30).WithMessage("Color name must be at most 30 character!")
                .MinimumLength(1).WithMessage("Color name must be at least 1 character!");

            RuleFor(x => x.HexCode).NotEmpty().WithMessage("Hex Code is required!");

            RuleFor(x => x.HexCode)
                .Matches("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$").WithMessage("Hex Code must be right format!");
        }
    }
}
