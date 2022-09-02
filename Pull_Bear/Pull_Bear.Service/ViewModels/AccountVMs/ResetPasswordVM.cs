using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.AccountVMs
{
    public class ResetPasswordVM
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordVMValidator : AbstractValidator<ResetPasswordVM>
    {
        public ResetPasswordVMValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("You must confirm new password!");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password is not as same as Confirm Password!");
        }
    }
}
