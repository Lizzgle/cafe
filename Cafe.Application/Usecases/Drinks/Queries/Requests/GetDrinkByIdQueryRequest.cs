using Cafe.Application.Common.DTOs.Drinks;
using MediatR;

namespace Cafe.Application.Usecases.Drinks.Queries.Requests;

public class GetDrinkByIdQueryRequest : IRequest<DrinkDto>
{
    required public Guid Id { get; set; }
}
