using FluentValidation;
using RentMyCar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMyCar.Validators
{
    public class CarViewValidator : AbstractValidator<CarView>
    {
        public CarViewValidator()
        {
            RuleFor(x => x.CarId).NotNull();
            RuleFor(x => x.Manufactor).MaximumLength(30).NotNull();
            RuleFor(x => x.Model).MaximumLength(50).NotNull();
            RuleFor(x => x.Year).InclusiveBetween(1940, DateTime.Now.Year).NotNull();
        }
    }
}
