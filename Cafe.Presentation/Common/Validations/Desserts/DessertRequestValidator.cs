using Cafe.Presentation.Common.Requests.Desserts;
using FluentValidation;

namespace Cafe.Presentation.Common.Validations.Desserts;

public class DessertRequestValidator : AbstractValidator<DessertRequest>
{
    public DessertRequestValidator() 
    {
        RuleFor(d => d.Name).NotEmpty().MaximumLength(20);
        RuleFor(d => d.Description).MaximumLength(100);
        RuleFor(d => d.Price).GreaterThan(0).Must(price => price.ToString("F2") == price.ToString());
        RuleFor(d => d.Calories).NotEmpty().GreaterThan(0);
    }
}
