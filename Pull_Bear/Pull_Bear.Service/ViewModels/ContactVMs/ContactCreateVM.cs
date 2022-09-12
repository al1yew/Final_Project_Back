using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ContactVMs
{
    public class ContactCreateVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }

    public class ContactCreateVMValidator : AbstractValidator<ContactCreateVM>
    {
        public ContactCreateVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(40).WithMessage("Enter Name in correct way!");
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(40).WithMessage("Enter Surname in correct way!");
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(40).WithMessage("Enter Phone in correct way!");
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).WithMessage("Enter Email in correct way!");
            RuleFor(x => x.Message).NotEmpty().MaximumLength(1000).WithMessage("Enter Message in correct way!");
        }
    }
}
