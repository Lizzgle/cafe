using Cafe.Presentation.Common.Requests.Users;
using FluentValidation;

namespace Cafe.Presentation.Common.Validations.Users;

public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator() 
    {
        RuleFor(r => r.RefreshToken).NotEmpty();
        RuleFor(r => r.Jwt).NotEmpty();
    }
}
