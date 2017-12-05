using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using FluentValidation;

namespace RentMyCar.Validators
{
    public class AdressValidator : AbstractValidator<Adress>
    {
        public AdressValidator()
        {
            RuleFor(x => x.AdressId).NotNull();
            RuleFor(x => x.PostalCode).MaximumLength(38).NotNull();
            RuleFor(x => x.StreetName).MaximumLength(50).NotNull();
            RuleFor(x => x.StreetNumber).LessThan(1000).NotNull();
            RuleFor(x => x.City).MaximumLength(50).NotNull();
        }

    }
}
