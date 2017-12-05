using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using FluentValidation;

namespace RentMyCar.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Login).Length(1, 30).NotNull();
            RuleFor(x => x.Password).Length(5, 30).NotNull();
            RuleFor(x => x.Mail).EmailAddress().NotNull();
            RuleFor(x => x.PhoneNumber).Length(8, 12).NotNull();
        }
    }
}
