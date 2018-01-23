using FluentValidation;
using RentMyCar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMyCar.Validators
{
    public class RegisterViewValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewValidator()
        {
            RuleFor(x => x.UserName).NotNull().MaximumLength(30);
            RuleFor(x => x.Password).NotNull().MaximumLength(30);
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.FirstName).NotNull().MaximumLength(30);
            RuleFor(x => x.LastName).NotNull().MaximumLength(30);
        }
    }
}
