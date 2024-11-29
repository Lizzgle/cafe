using Cafe.Application.Common.DTOs.Desserts;
using MediatR;

namespace Cafe.Application.Usecases.Desserts.Queries.Requests;

public class GetDessertsQueryRequest : IRequest<List<ShortDessertDto>>
{
}
