using Contracts.Entity;
using FluentValidation;

namespace Contracts.Validators
{
    public class UserLoginValidator : AbstractValidator<LoginCommand>
    {
        public UserLoginValidator()
        {
            RuleFor(loginCommand => loginCommand.UserName)
                .NotEmpty().WithMessage("Username can not be empty");

            RuleFor(loginCommand => loginCommand.Password)
                .NotEmpty().WithMessage("Password can not be empty");
        }
    }
}