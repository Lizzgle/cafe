using Cafe.Presentation.Common.Requests.Users;
using FluentValidation;

namespace Cafe.Presentation.Common.Validations.Users;

public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
{
    public UpdateRequestValidator()
    {
        RuleFor(u => u.Name).NotEmpty().MaximumLength(20);
        RuleFor(u => u.DateOfBirth).NotEmpty();
    }
}
