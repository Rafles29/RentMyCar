using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using FluentValidation;

namespace RentMyCar.Validators
{
    public class RentValidator : AbstractValidator<Rent>
    {
        public RentValidator()
        {
            RuleFor(x => x.RentId).NotNull();
            RuleFor(x => x.EndDate).NotNull();
        }
    }
}
