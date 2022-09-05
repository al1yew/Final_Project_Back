using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.AccountVMs
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
        public int GenderId { get; set; }
    }

    public class RegisterVMValidator : AbstractValidator<RegisterVM>
    {
        public RegisterVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("SurName is required!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required!");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone is required!");
            RuleFor(x => x.PhoneNumber).Matches(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$").WithMessage("Phone is in incorrect variant");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required in right format!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!");
        }
    }
}
