using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.AppUserVMs
{
    public class AppUserUpdateVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class AppUserUpdateVMValidator : AbstractValidator<AppUserUpdateVM>
    {
        public AppUserUpdateVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("SurName is required!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required!");
            RuleFor(x => x.Phone).Matches(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$").WithMessage("Phone is in incorrect variant");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required in right format!");
        }
    }
}
