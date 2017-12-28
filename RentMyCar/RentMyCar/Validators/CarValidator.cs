using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using FluentValidation;

namespace RentMyCar.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.CarId).NotNull();
            RuleFor(x => x.Manufactor).MaximumLength(30).NotNull();
            RuleFor(x => x.Model).MaximumLength(50).NotNull();
            RuleFor(x => x.Year).InclusiveBetween(1940,DateTime.Now.Year).NotNull();
            RuleFor(x => x.AvatarImage).NotNull();
        }
    }
}
