using Cafe.Application.Common.DTOs.Drinks;
using MediatR;

namespace Cafe.Application.Usecases.Drinks.Queries.Requests;

public class GetDrinksQueryRequest : IRequest<List<DrinkDto>>
{
}
