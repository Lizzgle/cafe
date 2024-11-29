using Cafe.Presentation.Common.Requests.Feedbacks;
using FluentValidation;

namespace Cafe.Presentation.Common.Validations.Feedbacks;

public class CreateFeedbackRequestValidator : AbstractValidator<CreateFeedbackRequest>
{
    public CreateFeedbackRequestValidator() 
    {
        RuleFor(f => f.Rating).NotEmpty().InclusiveBetween(1, 5);
    }
}
