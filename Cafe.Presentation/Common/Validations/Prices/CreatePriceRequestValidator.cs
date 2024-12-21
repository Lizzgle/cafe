using Cafe.Presentation.Common.Requests.Prices;
using FluentValidation;

namespace Cafe.Presentation.Common.Validations.Prices;

public class CreatePriceRequestValidator : AbstractValidator<CreatePriceRequest>
{
    public CreatePriceRequestValidator() 
    {
        RuleFor(p => p.SizeName).NotEmpty();
        RuleFor(p => p.DrinkId).NotEmpty();
        RuleFor(p => p.Cost).GreaterThan(0).Must(price => price.ToString("F2") == price.ToString());
    }
}
