using Cafe.Presentation.Common.Requests.Users;
using FluentValidation;

namespace Cafe.Presentation.Common.Validations.Users;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(u => u.Login).NotEmpty().MaximumLength(20);
        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(6)
            .Matches("[A-Z]")
            .Matches("[0-9]");
    }
}
