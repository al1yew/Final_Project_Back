using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.AddressVMs
{
    public class AddressCreateVM
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public bool IsMain { get; set; }
        public bool Save { get; set; }
        public string AppUserId { get; set; }
    }

    //public class AddressCreateVMValidator : AbstractValidator<AddressCreateVM>
    //{
    //    public AddressCreateVMValidator()
    //    {
    //        RuleFor(x => x.Address1.Length).LessThanOrEqualTo(40).WithMessage("Address 1 must be max 40 symbols!");
    //        RuleFor(x => x.Address2.Length).LessThanOrEqualTo(40).WithMessage("Address 2 must be max 40 symbols!");
    //        RuleFor(x => x.City.Length).LessThanOrEqualTo(22).WithMessage("City must be max 22 symbols!");
    //        RuleFor(x => x.Country.Length).LessThanOrEqualTo(60).WithMessage("Country must be max 60 symbols!");
    //        RuleFor(x => x.ZipCode.Length).LessThanOrEqualTo(12).WithMessage("Zip code must be max 12 symbols!");
    //    }
    //}
}
