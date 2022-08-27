using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.TagVMs
{
    public class TagCreateVM
    {
        public string Name { get; set; }
    }

    public class TagCreateVMValidator : AbstractValidator<TagCreateVM>
    {
        public TagCreateVMValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tag name is crucial for creating!")
                .MaximumLength(15).WithMessage("Maximum length for tag is 15 simbols!")
                .MinimumLength(1).WithMessage("Minimum length for tag is 1 symbol!");
        }
    }
}
