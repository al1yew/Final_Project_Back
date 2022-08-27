using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.TagVMs
{
    public class TagUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TagUpdateVMValidator : AbstractValidator<TagUpdateVM>
    {
        public TagUpdateVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tag name is crucial for update!");
        }
    }
}
