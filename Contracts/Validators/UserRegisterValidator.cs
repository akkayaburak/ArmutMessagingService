using Contracts.Entity;
using FluentValidation;

namespace Contracts.Validators
{
    public class UserRegisterValidator : AbstractValidator<RegisterCommand>
    {
        public UserRegisterValidator()
        {
            RuleFor(registerCommand => registerCommand.UserName)
                .NotEmpty().WithMessage("Username can not be empty");

            RuleFor(RegisterCommand => RegisterCommand.Password)
                .NotEmpty().WithMessage("Password can not be empty");
        }
    }
}