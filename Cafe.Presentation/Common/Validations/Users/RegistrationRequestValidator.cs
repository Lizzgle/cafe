using Cafe.Presentation.Common.Requests.Users;
using FluentValidation;

namespace Cafe.Presentation.Common.Validations.Users
{
    public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationRequestValidator() 
        {
            RuleFor(u => u.Login).NotEmpty().MaximumLength(20);
            RuleFor(u => u.Name).NotEmpty().MaximumLength(20);
            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(6)
                .Matches("[A-Z]")
                .Matches("[0-9]");
            RuleFor(u => u.DateOfBirth).NotEmpty();
        }
    }
}
