using FluentValidation;
using Pull_Bear.Core.Enums;
using Pull_Bear.Service.ViewModels.OrderItemVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.OrderVMs
{
    public class OrderCreateVM
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public double Price { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }
        public string AppUserId { get; set; }
        public IEnumerable<OrderItemListVM> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public class OrderCreateVMValidator : AbstractValidator<OrderCreateVM>
    {
        public OrderCreateVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Surname is required!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number is required!");
            RuleFor(x => x.Address1).NotEmpty().WithMessage("Address1 is required!");
            RuleFor(x => x.Address2).NotEmpty().WithMessage("Address2 is required!");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required!");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required!");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("ZipCode is required!");
        }
    }
}
