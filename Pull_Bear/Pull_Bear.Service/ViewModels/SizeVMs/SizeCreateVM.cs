using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.SizeVMs
{
    public class SizeCreateVM
    {
        public string Name { get; set; }
    }

    public class SizeCreateVMValidator : AbstractValidator<SizeCreateVM>
    {
        public SizeCreateVMValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Size name is required!")
                .MaximumLength(5).WithMessage("Size name must be at most 5 character!")
                .MinimumLength(1).WithMessage("Size name must be at least 1 character!");
        }
    }

}
