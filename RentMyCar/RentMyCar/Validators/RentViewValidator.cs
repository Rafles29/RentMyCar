using FluentValidation;
using RentMyCar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMyCar.Validators
{
    public class RentViewValidator : AbstractValidator<RentView>
    {
        public RentViewValidator()
        {
            RuleFor(x => x.CarId).NotNull().GreaterThan(0);
            RuleFor(x => x.StartDate).NotNull().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.EndDate).NotNull().GreaterThanOrEqualTo(DateTime.Now).GreaterThanOrEqualTo(x => x.StartDate);
            RuleFor(x => x.Adress).NotNull();
        }
    }
}
