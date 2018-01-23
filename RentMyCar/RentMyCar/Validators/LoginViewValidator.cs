using FluentValidation;
using RentMyCar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMyCar.Validators
{
    public class LoginViewValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(30);
        }
    }
}
