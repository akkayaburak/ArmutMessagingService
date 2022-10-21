using Contracts.Entity;
using FluentValidation;

namespace Contracts.Validators
{
    public class SendMessageValidator : AbstractValidator<MessageCommand>
    {
        public SendMessageValidator()
        {
            RuleFor(messageCommand => messageCommand.Sender)
                .NotEmpty().WithMessage("Sender can not be empty");

            RuleFor(messageCommand => messageCommand.Receiver)
                .NotEmpty().WithMessage("Receiver can not be empty");

            RuleFor(messageCommand => messageCommand.Content)
                .NotEmpty().WithMessage("Content can not be empty");
        }
    }
}