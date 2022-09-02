using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.AppUserVMs
{
    public class AppUserCreateVM
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class AppUserCreateVMValidator : AbstractValidator<AppUserCreateVM>
    {
        public AppUserCreateVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("SurName is required!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required!");
            RuleFor(x => x.Phone).Matches(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$").WithMessage("Phone is in incorrect variant");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required in right format!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword is required!");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password does not match to Confirm Password!");
        }
    }
}
