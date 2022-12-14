using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pull_Bear.Service.ViewModels.AppUserVMs
{
    public class AppUserUpdateVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class AppUserUpdateVMValidator : AbstractValidator<AppUserUpdateVM>
    {
        public AppUserUpdateVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.Name.Length).LessThanOrEqualTo(30).WithMessage("Name must be at most 30 characters!");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("SurName is required!");
            RuleFor(x => x.SurName.Length).LessThanOrEqualTo(30).WithMessage("Surname must be at most 30 characters!!");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone is required!");
            RuleFor(x => x.PhoneNumber).Matches(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$").WithMessage("Phone is in incorrect variant");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required in right format!");
            RuleFor(x => x.NewPassword).Equal(x => x.ConfirmPassword).WithMessage("Password does not match to Confirm Password!");

            RuleFor(x => x).Custom((x, y) =>
            {
                if (x.NewPassword != null)
                {
                    if (x.NewPassword.Length < 8)
                    {
                        y.AddFailure("Password must be at least 8 characters!");
                    }
                }
            });
        }
    }
}
