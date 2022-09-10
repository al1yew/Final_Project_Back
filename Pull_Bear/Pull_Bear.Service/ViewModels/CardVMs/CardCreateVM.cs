using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.CardVMs
{
    public class CardCreateVM
    {
        public string CardNo { get; set; }
        public string CVV { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ExpireDate { get; set; }
        public bool IsMain { get; set; }
        public string AppUserId { get; set; }
    }

    public class CardCreateVMValidator : AbstractValidator<CardCreateVM>
    {
        public CardCreateVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required!");
            RuleFor(x => x.CardNo).NotEmpty().WithMessage("Card number is required!");
            RuleFor(x => x.ExpireDate).NotEmpty().WithMessage("Expire date is required!");
            RuleFor(x => x.CVV.ToString()).NotEmpty().WithMessage("CVV code is required!");

            RuleFor(x => x.ExpireDate)
                .Matches(@"\d{2}\/\d{4}").WithMessage("Expire Date must be right format!");

            RuleFor(x => x.CVV.ToString())
                .Matches(@"^[0-9]{3,4}$").WithMessage("CVV code must be right format!");

            RuleFor(x => x.CardNo.Length).GreaterThanOrEqualTo(16).WithMessage("Card number must be 16 digits");

        }
    }
}
