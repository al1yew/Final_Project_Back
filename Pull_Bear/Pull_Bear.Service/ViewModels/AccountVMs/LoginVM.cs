using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pull_Bear.Service.ViewModels.AccountVMs
{
    public class LoginVM
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginVMValidator : AbstractValidator<LoginVM>
    {
        public LoginVMValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("You must enter Email or login!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("You must enter Password!");
        }
    }
}
